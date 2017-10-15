namespace Logic.Interfaces
{
    public interface IKassaServices
    {
        decimal GetKasInhoud(int kassaId);
        void AddBedragToKas(decimal bedrag);
        void RemoveBedragFromKas(decimal bedrag);
    }
}
