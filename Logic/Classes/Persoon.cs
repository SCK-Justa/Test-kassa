using System;

namespace Logic.Classes
{
    public class Persoon
    {
        public int Id { get; private set; }
        public int Bondsnummer { get; private set; }
        public string Voornaam { get; private set; }
        public string Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public string Emailadres { get; private set; }
        public DateTime Geboortedatum { get; private set; }
        public string Geslacht { get; private set; }
        public string Telefoonnummer { get; private set; }
        public string Mobielnummer { get; private set; }
        public Adres Adres { get; private set; }
        public Oudercontact Oudercontact { get; private set; }
        public Bank Bank { get; private set; }


        public Persoon(int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, DateTime gebdatum, Adres adres, string telnr, string mbnr)
        {
            Bondsnummer = bnr;
            Voornaam = vnaam;
            Tussenvoegsel = tvoegsel;
            Achternaam = anaam;
            Emailadres = email;
            Geslacht = geslacht;
            Geboortedatum = gebdatum;
            Adres = adres;
            Telefoonnummer = telnr;
            Mobielnummer = mbnr;
        }

        public Persoon(int id, int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, DateTime gebdatum, Adres adres,
            string telnr, string mbnr)
            : this(bnr, vnaam, tvoegsel, anaam, email, geslacht, gebdatum, adres, telnr, mbnr)
        {
            Id = id;
        }

        public void SetBondsnummer(int bondsnummer)
        {
            Bondsnummer = bondsnummer;
        }

        public void SetVoornaam(string voornaam)
        {
            Voornaam = voornaam;
        }

        public void SetTussenvoegsel(string tussenvoegsel)
        {
            Tussenvoegsel = tussenvoegsel;
        }

        public void SetAchternaam(string achternaam)
        {
            Achternaam = achternaam;
        }

        public void SetEmailadres(string email)
        {
            Emailadres = email;
        }

        public void SetAdres(Adres adres)
        {
            Adres = adres;
        }

        public void SetTelefoonnummer(string telnr)
        {
            Telefoonnummer = telnr;
        }

        public void SetMobielnummer(string mbnr)
        {
            Mobielnummer = mbnr;
        }

        public void SetGeslacht(string geslacht)
        {
            Geslacht = geslacht;
        }

        public void SetGeboortedatum(DateTime gebdatum)
        {
            Geboortedatum = gebdatum;
        }

        public void SetBank(Bank bank)
        {
            Bank = bank;
        }

        public void SetOuderContact(Oudercontact contact)
        {
            Oudercontact = contact;
        }
    }
}
