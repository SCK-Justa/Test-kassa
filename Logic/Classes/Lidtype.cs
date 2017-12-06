namespace Logic.Classes
{
    public class LidType
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public bool Bestuur { get; private set; }
        public bool Commissie { get; private set; }

        public LidType(string naam, bool bestuur, bool commissie)
        {
            Naam = naam;
            Bestuur = bestuur;
            Commissie = commissie;
        }

        public LidType(int id, string naam, bool bestuur, bool commissie) : this(naam, bestuur, commissie)
        {
            Id = id;
        }
    }
}