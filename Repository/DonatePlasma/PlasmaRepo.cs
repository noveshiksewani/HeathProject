using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Helper;
using HeathProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.DonatePlasma
{
    public class PlasmaRepo : IPlasmaRepo
    {
        public testContext context;
        public PlasmaRepo(testContext context)
        {
            this.context = context;
        }
        DonationHelper db = new DonationHelper();
        public bool DonatePlasma(Plasma plasma,int userId)
        {
            if (plasma != null)
            {
                context.Plasmas.Add(plasma);
                context.SaveChanges();
                Donation donation = new Donation();

                donation = db.InsertDonation("Plasma", "Donor", userId, plasma.PlasmaId);
                context.Donations.Add(donation);
                context.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Plasma Details is Invalid");
        }

        public List<Plasma> GetAllPlasma()
        {
            return (from cp in context.Donations.Include(x => x.User)
                    join p in context.Plasmas on cp.DonationTypeId equals p.PlasmaId
                    where cp.DonationType == "plasma"
                    select new Plasma
                    {
                        PlasmaId = p.PlasmaId,
                        BloodType = p.BloodType,
                        User = cp.User
                    }).ToList();
        }
    }
}
