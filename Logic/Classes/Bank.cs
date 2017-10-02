namespace Logic.Classes
{
    public class Bank
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public string Rekeningnummer { get; private set; }

        public Bank(string naam, string nummer)
        {
            Naam = naam;
            Rekeningnummer = nummer;
        }

        public Bank(int id, string naam, string nummer):this(naam, nummer)
        {
            Id = id;
        }

        public void SetNaam(string naam)
        {
            Naam = naam;
        }

        public void SetRekeningnummer(string nummer)
        {
            Rekeningnummer = nummer;
        }
    }
}
