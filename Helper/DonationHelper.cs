using HeathProject.DbContexts;
using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Helper
{
    public class DonationHelper
    {
        public Donation InsertDonation(string donationType,string userType,int userId,int donationTypeId)
        {
            Donation donation = new Donation();
            donation.DonationType = donationType;
            donation.DonationTypeId =donationTypeId;
            donation.UserId = userId; 
            donation.UserType = userType;
            return donation;
        }
    }
}
