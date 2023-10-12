using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.DonatePlasma
{
    public interface IPlasmaRepo
    {
        bool DonatePlasma(Plasma plasma,int userId);
        List<Plasma> GetAllPlasma();
    }
}
