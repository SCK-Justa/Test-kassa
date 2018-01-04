using System.Collections.Generic;
using Logic.Classes.Enums;

namespace Logic.Interfaces
{
    public interface IKassaLogServices
    {
        void AddLogString(int kassaId, string log, KassaSoortEnum soort);
        List<string> GetKassaLog();
    }
}
