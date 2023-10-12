using HeathProject.Models;
using HeathProject.Repository.QuarantinePlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.QuarantinePlaces
{
    public class QuarantinePlaceService : IQuarantinePlaceService
    {
        public IQuarantinePlaceRepo quarantinePlaceRepo;
        public QuarantinePlaceService(IQuarantinePlaceRepo quarantinePlaceRepo)
        {
            this.quarantinePlaceRepo = quarantinePlaceRepo;
        }
        public List<QuarantinePlace> GetQuarantinePlaces()
        {
            return quarantinePlaceRepo.GetQuarantinePlaces();
        }

        public bool GiveQuarantinePlace(QuarantinePlace quarantine,int userId)
        {
            return quarantinePlaceRepo.GiveQuarantinePlace(quarantine,userId);
        }
    }
}
