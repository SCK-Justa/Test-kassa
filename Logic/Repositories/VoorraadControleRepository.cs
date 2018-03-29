using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class VoorraadControleRepository
    {
        private IVoorraadControleServices _voorraadControleServices;

        public VoorraadControleRepository(IVoorraadControleServices voorraadControleServices)
        {
            _voorraadControleServices = voorraadControleServices;
        }

        public List<VoorraadControle> GetVoorraadControles()
        {
            return _voorraadControleServices.GetVoorraadControles();
        }

        public List<VoorraadControle> GetVoorraadControlesFromProduct(Product product)
        {
            return _voorraadControleServices.GetVoorraadControlesFromProduct(product);
        }

        public int AddVoorraadControle(VoorraadControle controle)
        {
             return _voorraadControleServices.AddVoorraadControle(controle);
        }

        public void ChangeVoorraadControle(VoorraadControle controle, int oudeVoorraad, int nieuweVoorraad)
        {
            _voorraadControleServices.ChangeVoorraadControle(controle, oudeVoorraad, nieuweVoorraad);
        }
    }
}
