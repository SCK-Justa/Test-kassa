using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IOmzetServices
    {
        List<decimal> GetOmzetPerDag(int weeknr);
        List<decimal> GetOmzetPerWeek(int maand);
        List<decimal> GetOmzetPerMaand(int jaartal);
        List<decimal> GetOmzetPerJaar();
    }
}
