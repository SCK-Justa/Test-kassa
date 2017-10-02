namespace Logic.Classes
{
    public class Oudercontact
    {
        public int Id { get; private set; }
        public string Voornaam { get; private set; }
        public string Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public string Telefoonnummer1 { get; private set; }
        public string Telefoonnummer2 { get; private set; }
        public string Emailadres1 { get; private set; }
        public string Emailadres2 { get; private set; }

        public Oudercontact(string naam, string tussen, string achter, string tel1, string tel2, string email1, string email2)
        {
            Voornaam = naam;
            Tussenvoegsel = tussen;
            Achternaam = achter;
            Telefoonnummer1 = tel1;
            Telefoonnummer2 = tel2;
            Emailadres1 = email1;
            Emailadres2 = email2;
        }

        public Oudercontact(int id, string naam, string tussen, string achter, string tel1, string tel2, string email1,
            string email2): this(naam, tussen, achter, tel1, tel2, email1, email2)
        {
            Id = id;
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

        public void SetTelefoonnummer1(string tel)
        {
            Telefoonnummer1 = tel;
        }

        public void SetTelefoonnummer2(string tel)
        {
            Telefoonnummer2 = tel;
        }

        public void SetEmailadres1(string email)
        {
            Emailadres1 = email;
        }

        public void SetEmailadres2(string email)
        {
            Emailadres2 = email;
        }
    }
}
