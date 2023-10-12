using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.OxygenFolder
{
    public interface IOxygen
    {
        bool DonateOxygen(Oxygen oxygen,int userId);
        List<Oxygen> GetAllOxygen();

    }
}
