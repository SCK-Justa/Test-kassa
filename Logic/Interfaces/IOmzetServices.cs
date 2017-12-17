using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IOmzetServices
    {
        decimal GetOmzetPerDag(DateTime eersteDagVanDeWeek);
        List<decimal> GetOmzetPerWeek(DateTime eersteDagVanDeMaand);
        decimal GetOmzetPerMaand(DateTime begindag, DateTime einddag);
        decimal GetOmzetPerJaar(DateTime jaar);
        void SetBedragInKas(decimal bedrag);
    }
}
