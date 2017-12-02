using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ILedenLogServices
    {
        List<string> GetLedenLog();
        void AddLogString(string description, bool join, bool leave);
    }
}
