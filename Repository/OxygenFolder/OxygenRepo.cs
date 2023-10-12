using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Helper;
using HeathProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.OxygenFolder
{
    public class OxygenRepo : IOxygen
    {
        public testContext context;
        public OxygenRepo(testContext context)
        {
            this.context = context;
        }
        DonationHelper db = new DonationHelper();
        public bool DonateOxygen(Oxygen oxygen,int userId)
        {
            if (oxygen!= null)
            {
                context.Oxygens.Add(oxygen);
                context.SaveChanges();

                Donation donation = new Donation();

                donation = db.InsertDonation("Oxygen", "Donor", userId, oxygen.OxygenId);
                context.Donations.Add(donation);
                context.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Oxygen Details are Invalid");
        }

        public List<Oxygen> GetAllOxygen()
        {
            return (from cp in context.Donations.Include(x => x.User)
                          join p in context.Oxygens on cp.DonationTypeId equals p.OxygenId
                          where cp.DonationType == "oxygen"
                          select new Oxygen
                          {
                              OxygenId = p.OxygenId,
                              Provider = p.Provider,
                              Quantity = p.Quantity,
                              User = cp.User
                          }).ToList();
        }
    }
}
