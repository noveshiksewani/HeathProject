using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Helper;
using HeathProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.QuarantinePlaces
{
    public class QuarantinePlaceRepo : IQuarantinePlaceRepo
    {
        public testContext context;
        public QuarantinePlaceRepo(testContext context)
        {
            this.context = context;
        }
        DonationHelper db = new DonationHelper();
        public List<QuarantinePlace> GetQuarantinePlaces()
        {
            return (from cp in context.Donations.Include(x => x.User)
                    join p in context.QuarantinePlaces on cp.DonationTypeId equals p.PlaceId
                    where cp.DonationType == "Quarantine Place"
                    select new QuarantinePlace
                    {
                        PlaceId = p.PlaceId,
                        Address =p.Address,
                        Description = p.Description,
                        RoomNo = p.RoomNo,
                        User = cp.User
                    }).ToList();
        }

        public bool GiveQuarantinePlace(QuarantinePlace quarantine, int userId)
        {
            if(quarantine!=null)
            {
                context.QuarantinePlaces.Add(quarantine);
                context.SaveChanges();

                Donation donation = new Donation();

                donation = db.InsertDonation("Quarantine Place", "Donor", userId, quarantine.PlaceId);
                context.Donations.Add(donation);
                context.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Quarantine Place Details are Invalid");
        }
    }
}
