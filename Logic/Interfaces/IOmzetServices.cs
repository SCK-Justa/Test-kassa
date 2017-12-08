using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IOmzetServices
    {
        decimal GetOmzetPerDag(DateTime eersteDagVanDeWeek);
        List<decimal> GetOmzetPerWeek(DateTime eersteDagVanDeMaand);
        List<decimal> GetOmzetPerMaand(DateTime jaartal);
        decimal GetOmzetPerJaar(DateTime jaar);
    }
}
