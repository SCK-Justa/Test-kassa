using System.Collections.Generic;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class OmzetRepository
    {
        private IOmzetServices _omzetServices;
        public OmzetRepository(IOmzetServices _omzetServices)
        {
            this._omzetServices = _omzetServices;
        }
        public List<decimal> GetOmzetPerDag(int weeknr)
        {
            return _omzetServices.GetOmzetPerDag(weeknr);
        }

        public List<decimal> GetOmzetPerWeek(int maand)
        {
            return _omzetServices.GetOmzetPerWeek(maand);
        }

        public List<decimal> GetOmzetPerMaand(int jaartal)
        {
            return _omzetServices.GetOmzetPerMaand(jaartal);
        }

        public List<decimal> GetOmzetPerJaar()
        {
            return _omzetServices.GetOmzetPerJaar();
        }
    }
}
