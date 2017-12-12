using System.Collections.Generic;
using Logic.Interfaces;
using System;

namespace Logic.Repositories
{
    public class OmzetRepository
    {
        private IOmzetServices _omzetServices;
        public OmzetRepository(IOmzetServices _omzetServices)
        {
            this._omzetServices = _omzetServices;
        }
        public decimal GetOmzetPerDag(DateTime eersteDagVanDeWeek)
        {
            return _omzetServices.GetOmzetPerDag(eersteDagVanDeWeek);
        }

        public List<decimal> GetOmzetPerWeek(DateTime eersteDagVanDeMaand)
        {
            return _omzetServices.GetOmzetPerWeek(eersteDagVanDeMaand);
        }

        public List<decimal> GetOmzetPerMaand(DateTime jaartal)
        {
            return _omzetServices.GetOmzetPerMaand(jaartal);
        }

        public decimal GetOmzetPerJaar(DateTime jaar)
        {
            return _omzetServices.GetOmzetPerJaar(jaar);
        }

        public void SetBedragInKas(decimal bedrag)
        {
            _omzetServices.SetBedragInKas(bedrag);
        }
    }
}
