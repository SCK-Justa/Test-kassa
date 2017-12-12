using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface ILedenLogServices
    {
        List<string> GetLedenLog();
        void AddLogString(string description, bool join, bool leave);
    }
}
