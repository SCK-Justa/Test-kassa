namespace Logic.Classes
{
    public class Adres
    {
        public int Id { get; private set; }
        public string Straatnaam { get; private set; }
        public string Huisnummer { get; private set; }
        public string Postcode { get; private set; }
        public string Plaats { get; private set; }
        public string Emailadres { get; private set; }


        public Adres(string straat, string hnr, string pcode, string plaats)
        {
            Straatnaam = straat;
            Huisnummer = hnr;
            Postcode = pcode;
            Plaats = plaats;
        }

        public Adres(int id, string straat, string hnr, string pcode, string plaats) : this(straat, hnr, pcode, plaats)
        {
            Id = id;
        }

        public void SetStraatnaam(string straatnaam)
        {
            Straatnaam = straatnaam;
        }

        public void SetHuisnummer(string huisnummer)
        {
            Huisnummer = huisnummer;
        }

        public void SetPostcode(string postcode)
        {
            Postcode = postcode;
        }

        public void SetPlaats(string plaats)
        {
            Plaats = plaats;
        }

        public void SetEmail(string email)
        {
            Emailadres = email;
        }
    }
}
