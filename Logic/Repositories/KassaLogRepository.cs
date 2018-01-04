using System.Collections.Generic;
using Logic.Classes.Enums;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class KassaLogRepository
    {
        private IKassaLogServices _kassaLogServices;
        public KassaLogRepository(IKassaLogServices _kassaLogServices)
        {
            this._kassaLogServices = _kassaLogServices;
        }
        public void AddLogString(int kassaId, string log, KassaSoortEnum soort)
        {
            _kassaLogServices.AddLogString(kassaId, log, soort);
        }

        public List<string> GetKassaLog()
        {
            return _kassaLogServices.GetKassaLog();
        }
    }
}
