using System;
using System.Collections.Generic;

namespace Logic.Classes
{
    public class Bestelling
    {
        private List<Product> _producten;
        public int Id { get; private set; }
        public Lid Lid { get; private set; }
        public string Naam { get; private set; }
        public DateTime Datum { get; private set; }
        public DateTime DatumBetaald { get; private set; }
        public bool Betaald { get; private set; }
        public int KassaId { get; private set; }
        public decimal TotaalPrijs { get; private set; }
        public decimal TotaalLedenPrijs { get; private set; }
        public bool BetaaldMetBonnen { get; private set; }
        public decimal BetaaldBedrag { get; private set; }
        public bool BetaaldBestuur { get; private set; }
        public string Opmerking { get; private set; }

        public Bestelling(DateTime datum)
        {
            Datum = datum;
            _producten = new List<Product>();
            if (DatumBetaald < DateTime.Parse("01-01-2017"))
            {
                DatumBetaald = DateTime.Parse("01-01-1900");
            }
        }
        public Bestelling(Lid lid, DateTime datum) : this(datum)
        {
            Lid = lid;
            Naam = "";
        }

        public Bestelling(string naam, DateTime datum) : this(datum)
        {
            Naam = naam;
            Lid = null;
        }

        public Bestelling(int id, Lid lid, DateTime datum) : this(datum)
        {
            Id = id;
            Lid = lid;
        }

        public Bestelling(int id, string naam, DateTime datum) : this(datum)
        {
            Id = id;
            Naam = naam;
        }

        public Bestelling(int id, string naam, string datum, string datumBetaald)
        {
            Id = id;
            Naam = naam;
            Datum = DateTime.Parse(datum);
            DatumBetaald = DateTime.Parse(datumBetaald);
            KassaId = 0;
            Betaald = false;
        }

        public void SetId(int id)
        {
            Id = id;
        }
        public void SetPersoon(Lid lid)
        {
            Lid = lid;
            Naam = "";
        }

        public void SetNaam(string naam)
        {
            Naam = naam;
            Lid = null;
        }

        public void SetDatum(DateTime datum)
        {
            Datum = datum;
        }

        public void SetDatumBetaald(DateTime datum)
        {
            DatumBetaald = datum;
        }

        public void SetBetaaldBedrag(decimal bedrag)
        {
            BetaaldBedrag = bedrag;
        }

        public void SetKassaId(int kassaId)
        {
            KassaId = kassaId;
        }

        public void SetBetaald(bool betaald)
        {
            Betaald = betaald;
        }

        public void SetTotaalPrijs(decimal prijs)
        {
            TotaalPrijs = prijs;
        }

        public void SetTotaalLedenPrijs(decimal prijs)
        {
            TotaalLedenPrijs = prijs;
        }

        public void SetBetaaldMetBonnen(bool value)
        {
            BetaaldMetBonnen = value;
        }

        public void SetOpmerking(string value)
        {
            Opmerking = value;
        }

        public void SetBetaaldBestuur(bool value)
        {
            BetaaldBestuur = value;
        }

        public void AddProductenToList(List<Product> producten)
        {
            _producten = producten;
            if (_producten != null)
            {
                foreach (Product p in producten)
                {
                    TotaalPrijs += p.Prijs;
                    TotaalLedenPrijs += p.Ledenprijs;
                }
            }
        }

        public List<Product> GetProducten()
        {
            return _producten;
        }

        public bool AddProductToList(Product product)
        {
            if (product.Voorraad > 0)
            {
                _producten.Add(product);
                product.SetVoorraad(product.Voorraad - 1);
                TotaalPrijs += product.Prijs;
                TotaalLedenPrijs += product.Ledenprijs;
                return true;
            }
            return false;
        }

        public void RemoveProductFromList(Product product)
        {
            foreach (Product p in _producten)
            {
                if (product.Id == p.Id)
                {
                    _producten.Remove(product);
                    product.SetVoorraad(product.Voorraad + 1);
                    TotaalPrijs -= product.Prijs;
                    TotaalLedenPrijs -= product.Ledenprijs;
                    break;
                }
            }
        }

        public void Afrekenen(decimal bedrag, DateTime datumBetaald, bool bestuur)
        {
            BetaaldBedrag = bedrag;
            Betaald = true;
            DatumBetaald = datumBetaald;
            BetaaldBestuur = bestuur;
        }

        public string GetBesteller()
        {
            if (Lid != null)
            {
                if (Lid.Tussenvoegsel != "")
                {
                    return Lid.Voornaam + " " + Lid.Tussenvoegsel + " " + Lid.Achternaam;
                }
                return Lid.Voornaam + " " + Lid.Achternaam;
            }
            return Naam;
        }
    }
}
