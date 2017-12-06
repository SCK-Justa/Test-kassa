﻿using System;
using System.Collections.Generic;

namespace Logic.Classes
{
    public class Lid : Persoon
    {
        public string Functie {  get; private set; }
        public DateTime LidVanaf {  get; private set; }
        public List<string> Spelden {  get; }
        public Klasse NhbKlasse {  get; private set; }
        public Klasse Klasse {  get; private set; }
        public Oudercontact OC { get; private set; }
        public LidType Type { get; private set; }
        public Lid(DateTime lidvanaf, int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, 
            DateTime gebdatum, Adres adres, string telnr, string mbnr, LidType type) : base(bnr, vnaam, tvoegsel, anaam, email, geslacht, gebdatum, adres, telnr, mbnr)
        {
            LidVanaf = lidvanaf;
            Spelden = new List<string>();
            Type = type;
        }

        public Lid(DateTime lidvanaf, Klasse nhbKlasse, Klasse klasse, int id, int bnr, string vnaam, string tvoegsel, string anaam, string email, string geslacht, 
            DateTime gebdatum, Adres adres, string telnr, string mbnr, LidType type) : base(id, bnr, vnaam, tvoegsel, anaam, email, geslacht, gebdatum, adres, telnr, mbnr)
        {
            Klasse = klasse;
            NhbKlasse = nhbKlasse;
            LidVanaf = lidvanaf;
            Spelden = new List<string>();
            Type = type;
        }

        public void SetFunctie(string functie)
        {
            Functie = functie;
        }

        public void SetKlasse(Klasse klasse)
        {
            Klasse = klasse;
        }

        public void SetNhbKlasse(Klasse klasse)
        {
            NhbKlasse = klasse;
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

        public int GetBondsnummer()
        {
            if (Bondsnummer > 0)
            {
                return Bondsnummer;
            }
            return 0;
        }

        public string GetNHBKlasseNaam()
        {
            if(NhbKlasse != null)
            {
                return NhbKlasse.Naam;
            }
            return null;
        }

        public void AddLidType(LidType type)
        {
            Type = type;
        }

        public Klasse CalculateKlasse(List<Klasse> klasses)
        {
            int beginleeftijd = DateTime.Now.Year - Geboortedatum.Year;
            Klasse klas = null;
            foreach(Klasse k in klasses)
            {
                if(beginleeftijd >= k.BeginLeeftijd && beginleeftijd <= k.EindLeeftijd)
                {
                    klas = k;
                    break;
                }
            }
            if(klas == null)
            {
                throw new Exception("Persoon is te jong of te oud om lid te worden.");
            }
            return klas;
        }
    }
}
