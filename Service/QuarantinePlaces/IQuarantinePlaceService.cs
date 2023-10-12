using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.QuarantinePlaces
{
    public interface IQuarantinePlaceService
    {
        bool GiveQuarantinePlace(QuarantinePlace quarantine,int userId);
        List<QuarantinePlace> GetQuarantinePlaces();
    }
}
