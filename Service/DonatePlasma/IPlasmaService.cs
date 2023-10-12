using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.DonatePlasma
{
    public interface IPlasmaService
    {
        bool DonatePlasma(Plasma plasma,int userId);
        List<Plasma> GetAllPlasma();
    }
}
