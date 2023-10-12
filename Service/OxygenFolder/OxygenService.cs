using HeathProject.Models;
using HeathProject.Repository.OxygenFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.OxygenFolder
{
    public class OxygenService : IOxygenService
    {
        public IOxygen oxygenRepo;
        public OxygenService(IOxygen oxygenRepo)
        {
            this.oxygenRepo = oxygenRepo;
        }
        public bool DonateOxygen(Oxygen oxygen, int userId)
        {
            return oxygenRepo.DonateOxygen(oxygen,userId);
        }

        public List<Oxygen> GetAllOxygen()
        {
            return oxygenRepo.GetAllOxygen();
        }
    }
}
