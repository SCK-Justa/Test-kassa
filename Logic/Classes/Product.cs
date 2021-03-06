﻿using System.Collections.Generic;

namespace Logic.Classes
{
    public class Product
    {
        private List<VoorraadControle> voorraadOpbouw;
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public string Soort { get; private set; }
        public int Voorraad { get; private set; } // Hoeveel is er in het magazijn op voorraad
        public decimal Ledenprijs { get; private set; }
        public decimal Prijs { get; private set; }

        public Product(string naam, string soort, int voorraad, decimal ledenprijs, decimal prijs)
        {
            Naam = naam;
            Soort = soort;
            Voorraad = voorraad;
            Ledenprijs = ledenprijs;
            Prijs = prijs;
            voorraadOpbouw = new List<VoorraadControle>();
        }

        public Product(int id, string naam, string soort, int voorraad, decimal ledenprijs, decimal prijs) : this(naam, soort, voorraad, ledenprijs, prijs)
        {
            Id = id;
        }

        public void SetNaam(string naam)
        {
            Naam = naam;
        }

        public void SetSoort(string soort)
        {
            Soort = soort;
        }

        public void SetVoorraad(int voorraad)
        {
            Voorraad = voorraad;
        }

        public void SetLedenprijs(decimal lprijs)
        {
            Ledenprijs = lprijs;
        }

        public void SetPrijs(decimal prijs)
        {
            Prijs = prijs;
        }

        public void AddVoorraadControle(VoorraadControle controle)
        {
            voorraadOpbouw.Add(controle);
        }

        public List<VoorraadControle> GetVoorraadOpbouw()
        {
            return voorraadOpbouw;
        }

        public void AddVoorraadOpbouw(List<VoorraadControle> opbouw)
        {
            if (opbouw != null)
            {
                voorraadOpbouw = opbouw;
            }
        }
    }
}
