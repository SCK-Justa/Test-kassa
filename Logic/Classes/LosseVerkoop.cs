using System;

namespace Logic.Classes
{
    public class LosseVerkoop : Product
    {
        public int LosseVerkoopId { get; private set; }
        public DateTime BestelDatum { get; private set; }
        public bool IsLid { get; private set; }
        public bool BonnenBetaling { get; private set; }

        public LosseVerkoop(int losseVerkoopId, DateTime bestelDatum, bool isLid, bool bonnenBetaling, int prodId, string prodNaam, string soortNaam, int voorraad, decimal ledenprijs, decimal prijs) :
            base(prodId, prodNaam, soortNaam, voorraad, ledenprijs, prijs)
        {
            LosseVerkoopId = losseVerkoopId;
            BestelDatum = bestelDatum;
            IsLid = isLid;
            BonnenBetaling = bonnenBetaling;
        }
        public LosseVerkoop(DateTime bestelDatum, bool isLid, bool bonnenBetaling, int prodId, string prodNaam, string soortNaam, int voorraad, decimal ledenprijs, decimal prijs) :
            base(prodId, prodNaam, soortNaam, voorraad, ledenprijs, prijs)
        {
            BestelDatum = bestelDatum;
            IsLid = isLid;
            BonnenBetaling = bonnenBetaling;
        }

        public void SetLosseVerkoopId(int id)
        {
            LosseVerkoopId = id;
        }

        public void SetBonnenbetaling(bool bonnen)
        {
            BonnenBetaling = bonnen;
        }
    }
}
