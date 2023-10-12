using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.OxygenFolder
{
    public interface IOxygenService
    {
        bool DonateOxygen(Oxygen oxygen,int userId);
        List<Oxygen> GetAllOxygen();
    }
}
