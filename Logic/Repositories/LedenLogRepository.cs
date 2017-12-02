using Logic.Interfaces;
using System.Collections.Generic;

namespace Logic.Repositories
{
    public class LedenLogRepository
    {
        ILedenLogServices _ledenLogServices;

        public LedenLogRepository(ILedenLogServices ledenlogServices)
        {
            _ledenLogServices = ledenlogServices;
        }

        public void AddLogString(string description, bool join, bool leave)
        {
            _ledenLogServices.AddLogString(description, join, leave);
        }

        public List<string> GetLedenLog()
        {
            return _ledenLogServices.GetLedenLog();
        }
    }
}
