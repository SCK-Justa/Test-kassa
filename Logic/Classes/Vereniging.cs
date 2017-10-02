using System.Collections.Generic;

namespace Logic.Classes
{
    public class Vereniging
    {
        public string Naam { get; private set; }
        public List<Lid> Leden { get; }
        public Adres Adres { get; private set; }

        public Vereniging(string naam, Adres adres)
        {
            Naam = naam;
            Adres = adres;
            Leden = new List<Lid>();
        }

        public void SetNaam(string naam)
        {
            Naam = naam;
        }

        public void SetAdres(Adres adres)
        {
            Adres = adres;
        }

        public bool VoegLidToe(Lid lid)
        {
            if (!LidCheck(lid))
            {
                Leden.Add(lid);
                return true;
            }
            return false;
        }

        public bool LidCheck(Lid lid)
        {
            foreach (Lid l in Leden)
            {
                if (l.Achternaam == lid.Achternaam)
                {
                    if (l.Voornaam == lid.Voornaam)
                    {
                        return true; // Persoon is al lid
                    }
                }
            }
            return false; // Persoon is nog geen lid
        }
    }
}
