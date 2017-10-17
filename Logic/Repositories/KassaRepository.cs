using Logic.Interfaces;

namespace Logic.Repositories
{
    public class KassaRepository
    {
        private IKassaServices _kassaServices;

        public KassaRepository(IKassaServices kassaServices)
        {
            _kassaServices = kassaServices;
        }
        public decimal GetKasInhoud(int kassaId)
        {
            return _kassaServices.GetKasInhoud(kassaId);
        }

        public void AddBedragToKas(decimal bedrag)
        {
            _kassaServices.AddBedragToKas(bedrag);
        }

        public void RemoveBedragFromKas(decimal bedrag)
        {
            _kassaServices.RemoveBedragFromKas(bedrag);
        }
    }
}
