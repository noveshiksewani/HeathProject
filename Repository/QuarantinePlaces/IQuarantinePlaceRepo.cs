using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.QuarantinePlaces
{
    public interface IQuarantinePlaceRepo
    {
        bool GiveQuarantinePlace(QuarantinePlace quarantine,int userId);
        List<QuarantinePlace> GetQuarantinePlaces();
    }
}
