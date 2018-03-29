using System;
using Logic.Classes.Enums;

namespace Logic.Classes
{
    public class VoorraadControle
    {
        public int Id { get; private set; }
        public Product Product { get; }
        public Lid Controleur { get; }
        public DateTime DatumControle { get; }
        public int OudeVoorraad { get; private set; }
        public int NieuweVoorraad { get; private set; }
        public VoorraadEnum Opmerking { get; }

        public VoorraadControle(Product product, Lid controleur, DateTime datumControle, int oud, int nieuw, VoorraadEnum opmerking)
        {
            Product = product;
            Controleur = controleur;
            DatumControle = datumControle;
            OudeVoorraad = oud;
            NieuweVoorraad = nieuw;
            Opmerking = opmerking;
        }

        public VoorraadControle(int id, Product product, Lid controleur, DateTime datumControle, int oud, int nieuw, VoorraadEnum opmerking) 
            : this(product, controleur, datumControle, oud, nieuw, opmerking)
        {
            Id = id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetOudeVoorraad(int value)
        {
            OudeVoorraad = value;
        }

        public void SetNieuweVoorraad(int value)
        {
            NieuweVoorraad = value;
        }

        public string GetControleur()
        {
            if (Controleur != null)
            {
                return Controleur.GetLidNaam();
            }
            return "";
        }
    }
}
