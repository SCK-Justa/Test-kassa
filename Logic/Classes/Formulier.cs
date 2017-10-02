using System;

namespace Logic.Classes
{
    public class Formulier
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public FormulierSoort Soort { get; private set; }
        public DateTime Datum { get; private set; }
        public string BankrekeningNummer { get; private set; }
        public decimal GeleendBedrag { get; private set; }
        public string Reden { get; private set; }
        public bool Contant { get; private set; }
        public string GeredenRoute { get; private set; }
        public decimal GemaakteKm { get; private set; }
        public string GetekendDoor { get; private set; }
        public Formulier(FormulierSoort soort, DateTime datum, string naam, string bankrekening, string reden, bool contant,
            string route, decimal geredenKm, decimal bedrag, string getekendDoor)
        {
            Soort = soort;
            Naam = naam;
            Datum = datum;
            BankrekeningNummer = bankrekening;
            Reden = reden;
            Contant = contant;
            GeredenRoute = route;
            GemaakteKm = geredenKm;
            GeleendBedrag = bedrag;
            GetekendDoor = getekendDoor;
        }

        public Formulier(int id, FormulierSoort soort, DateTime datum, string naam, string bankrekening, string reden, bool contant,
            string route, decimal geredenKm, decimal bedrag, string getekendDoor) : this(soort, datum, naam, bankrekening, reden, contant, route, geredenKm, bedrag, getekendDoor)
        {
            Id = id;
        }
    }
}
