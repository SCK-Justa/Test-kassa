using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IVoorraadControleServices
    {
        List<VoorraadControle> GetVoorraadControles();
        List<VoorraadControle> GetVoorraadControlesFromProduct(Product product);
        int AddVoorraadControle(VoorraadControle controle);
        void ChangeVoorraadControle(VoorraadControle controle, int oudeVoorraad, int nieuweVoorraad);
    }
}
