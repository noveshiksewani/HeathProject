using HeathProject.Models;
using HeathProject.Repository.DonatePlasma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.DonatePlasma
{
    public class PlasmaService : IPlasmaService
    {
        public IPlasmaRepo plasmaRepo;
        public PlasmaService(IPlasmaRepo plasmaRepo)
        {
            this.plasmaRepo = plasmaRepo;
        }
        public bool DonatePlasma(Plasma plasma,int userId)
        {
            return plasmaRepo.DonatePlasma(plasma,userId);
        }

        public List<Plasma> GetAllPlasma()
        {
            return plasmaRepo.GetAllPlasma();
        }
    }
}
