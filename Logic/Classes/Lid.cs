using System;
using System.Collections.Generic;

namespace Logic.Classes
{
    public class Lid : Persoon
    {
        public string Functie { get; private set; }
        public DateTime LidVanaf { get; private set; }
        public List<string> Spelden { get; }
        public Klasse NhbKlasse { get; private set; }
        public Klasse Klasse { get; private set; }
        public Lid(DateTime lidvanaf, Klasse nhbklasse, Klasse klasse, int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, 
            DateTime gebdatum, Adres adres, string telnr, string mbnr) : base(bnr, vnaam, tvoegsel, anaam, email, geslacht, gebdatum, adres, telnr, mbnr)
        {
            NhbKlasse = nhbklasse;
            LidVanaf = lidvanaf;
            Klasse = klasse;
            Spelden = new List<string>();
        }

        public Lid(DateTime lidvanaf, Klasse nhbklasse, Klasse klasse, int id, int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, 
            DateTime gebdatum, Adres adres, string telnr, string mbnr) : base(id, bnr, vnaam, tvoegsel, anaam, email, geslacht, gebdatum, adres, telnr, mbnr)
        {
            NhbKlasse = nhbklasse;
            LidVanaf = lidvanaf;
            Klasse = klasse;
            Spelden = new List<string>();
        }

        public void SetFunctie(string functie)
        {
            Functie = functie;
        }

        public void SetKlasse(Klasse klasse)
        {
            Klasse = klasse;
        }

        public void AddSpeld(string speld)
        {
            Spelden.Add(speld);
        }

        public bool RemoveSpeld(string speld)
        {
            foreach (string s in Spelden)
            {
                if (s == speld)
                {
                    Spelden.Remove(s);
                    return true; // Speld is gevonden
                }
            }
            return false; // Speld is niet gevoden
        }

        public string GetSpelden()
        {
            string spelden = "";
            foreach (string s in Spelden)
            {
                spelden += s + ";";
            }
            return spelden;
        }

        public string GetLidNaam()
        {
            if (Tussenvoegsel != "")
            {
                return Voornaam + " " + Tussenvoegsel + " " + Achternaam;
            }
            return Voornaam + " " + Achternaam;
        }
    }
}
