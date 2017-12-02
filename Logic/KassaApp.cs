using System;
using System.Collections.Generic;
using Logic.Classes;
using Logic.Repositories;
using Logic.Sql;

namespace Logic
{
    public class KassaApp
    {
        private DBConnectie _dbConnectie;
        private BestellingRepository _bestellingRepo;
        private LidRepository _ledenRepo;
        private AdresRepository _adresRepo;
        private BankRepository _bankRepo;
        private OudercontactRepository _oudercontactRepo;
        private AuthenticatieRepository _authRepo;
        private ProductBestellingRepository _productBestellingRepo;
        private ProductRepository _productRepo;
        private KassaRepository _kassaRepo;
        private OmzetRepository _omzetRepo;
        private LedenLogRepository _ledenLogRepo;
        private KlasseRepository _klassenRepo;

        private List<Authentication> _gebruikers;
        private List<Lid> _leden;
        private List<Product> _losseVerkopen;
        private List<Bestelling> _bestellingen;
        private List<Bestelling> _afgerekendeBestellingen;
        private List<Formulier> _formulieren;
        private int volgendBestellingNr;

        public int Id { get; private set; }
        public string Lokatie { get; private set; }
        public Voorraad Voorraad { get; private set; }
        public Authentication Authentication { get; private set; }
        public decimal BedragInKas { get; private set; }
        public bool DBConnection { get; private set; } // Geen connectie = false, dan draait de app lokaal, anders met database.

        public KassaApp(string lokatie)
        {
            try
            {
                Lokatie = lokatie;
                // Controleren van de connectie met de Database, is die er, dan data ophalen, anders niet.
                KassaAppSync(CheckDbConnection());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool CheckDbConnection()
        {
            _dbConnectie = new DBConnectie(@"Server=77.162.105.50,1433;Database=Clubmanagement;User ID=admin;Password=SintSebastiaan1819;");
            if (_dbConnectie.TryConnection())
            {
                DBConnection = true;
                return true;
            }
            DBConnection = false;
            return false;
        }

        private void KassaAppSync(bool connectie)
        {
            try
            {
                Voorraad = GetVoorraad();
                BedragInKas = 0;
                _formulieren = new List<Formulier>();
                _gebruikers = new List<Authentication>();
                _losseVerkopen = new List<Product>();
                if (connectie)
                {
                    Console.WriteLine("Connectie geslaagd.");
                    GetDatabaseStuff();
                    AddProductenFromDbToVoorraad();
                    _leden = GetLeden();
                    _gebruikers = GetGebruikers();
                    GetBestellingenFromDb();
                    BedragInKas = _kassaRepo.GetKasInhoud(0);
                    _gebruikers = _authRepo.GetAuthentications();
                    if (_afgerekendeBestellingen.Count > 1)
                    {
                        _afgerekendeBestellingen.Sort((x, y) => -x.DatumBetaald.CompareTo(y.DatumBetaald));
                    }
                }
                else
                {
                    Console.WriteLine("Connectie met database niet mogelijk. Admin toegevoegd aan inlogaccounts.");
                    _gebruikers.Add(new Authentication("Admin", "system", null, new AuthenticationSoort("Admin", true, false)));
                    GetBestellingenFromDb();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public KassaApp(int id, string lokatie) : this(lokatie)
        {
            Id = id;
        }

        public bool Login(string username, string password)
        {
            foreach (Authentication auth in _gebruikers)
            {
                if (auth.Username == username)
                {
                    if (auth.Password == password)
                    {
                        Authentication = auth;
                        return true;
                    }
                }
            }
            return false;
        }

        private void GetDatabaseStuff()
        {
            _ledenLogRepo = new LedenLogRepository(new SqlLedenLog(_dbConnectie.GetConnectieString()));
            _bestellingRepo = new BestellingRepository(new SqlBestelling(_dbConnectie.GetConnectieString()));
            _ledenRepo = new LidRepository(new SqlLid(_dbConnectie.GetConnectieString()));
            _adresRepo = new AdresRepository(new SqlAdres(_dbConnectie.GetConnectieString()));
            _bankRepo = new BankRepository(new SqlBank(_dbConnectie.GetConnectieString()));
            _oudercontactRepo = new OudercontactRepository(new SqlOudercontact(_dbConnectie.GetConnectieString()));
            _authRepo = new AuthenticatieRepository(new SqlAuthentication(_dbConnectie.GetConnectieString()));
            _productBestellingRepo = new ProductBestellingRepository(new SqlProductBestelling(_dbConnectie.GetConnectieString()));
            _productRepo = new ProductRepository(new SqlProduct(_dbConnectie.GetConnectieString()));
            _kassaRepo = new KassaRepository(new SqlKassa(_dbConnectie.GetConnectieString()));
            _omzetRepo = new OmzetRepository(new SqlOmzet(_dbConnectie.GetConnectieString()));
            _klassenRepo = new KlasseRepository(new SqlKlasse(_dbConnectie.GetConnectieString()));
        }

        public List<Formulier> GetFormulieren()
        {
            _formulieren.Sort((x, y) => -x.Datum.CompareTo(y.Datum));
            return _formulieren;
        }

        public decimal GetBedragInKas()
        {
            return BedragInKas;
        }

        public void AddAndereInkomsten(decimal value)
        {
            BedragInKas += value;
            _kassaRepo.AddBedragToKas(BedragInKas);
        }

        public void AddLid(Lid lid)
        {
            try
            {
                List<Klasse> klasses = _klassenRepo.GetKlasses();
                lid.SetAdres(_adresRepo.AddAdres(lid.Adres));
                lid.SetBank(_bankRepo.AddBank(lid.Bank));
                lid.SetOuderContact(_oudercontactRepo.AddOudercontact(lid.Oudercontact));
                lid.SetKlasse(lid.CalculateKlasse(klasses));
                lid.SetNhbKlasse(lid.CalculateKlasse(klasses));
                _ledenRepo.AddPersoon(lid);
                _ledenLogRepo.AddLogString(lid.GetLidNaam() + " is op " + lid.LidVanaf.ToShortDateString(), true, false);
                _leden.Add(lid);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void NeemBedragUitKas(decimal value)
        {
            try
            {
                if (!(value > BedragInKas))
                {
                    BedragInKas -= value;
                }
                else
                {
                    throw new Exception("Bedrag kan niet hoger zijn dan het bedrag aanwezig in de kas.");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public decimal GetTotaalOpgebracht()
        {
            decimal bedrag = 0;
            if (_afgerekendeBestellingen == null)
            {
                GetAfgerekendeBestellingen();
            }
            foreach (Bestelling bestelling in _afgerekendeBestellingen)
            {
                if (bestelling.TotaalPrijs == 0)
                {
                    bedrag += bestelling.TotaalLedenPrijs;
                }
                else
                {
                    bedrag += bestelling.TotaalPrijs;
                }
            }
            return bedrag;
        }

        public void AddGebruiker(string gebruikersnaam, string wachtwoord, string volledigenaam, bool isChecked)
        {
            //Authentication auth = new Authentication(gebruikersnaam, wachtwoord, volledigenaam, isChecked);
            //_gebruikers.Add(auth);
        }

        public List<Authentication> GetGebruikers()
        {
            //if (_gebruikers != null)
            //{
            //    return _gebruikers;
            //}
            return _authRepo.GetAuthentications();
        }

        public void AddBestelling(Lid lid, DateTime datum)
        {
            try
            {
                Bestelling bestelling;
                if (DBConnection)
                {
                    bestelling = new Bestelling(lid, datum);
                    int id = _bestellingRepo.AddBestellingMetPersoon(bestelling);
                    bestelling.SetId(id);
                    _bestellingen.Add(bestelling);
                }
                else
                {
                    bestelling = new Bestelling(volgendBestellingNr, lid, datum);
                    _bestellingen.Add(bestelling);
                    volgendBestellingNr++;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void AddBestelling(string name, DateTime datum)
        {
            try
            {
                Bestelling bestelling;
                if (DBConnection)
                {
                    bestelling = new Bestelling(name, datum);
                    int id = _bestellingRepo.AddBestellingMetNaam(bestelling);
                    bestelling.SetId(id);
                    _bestellingen.Add(bestelling);
                }
                else
                {
                    bestelling = new Bestelling(volgendBestellingNr, name, datum);
                    _bestellingen.Add(bestelling);
                    volgendBestellingNr++;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool RemoveProductVanBestelling(Bestelling bestelling, Product product)
        {
            if (DBConnection)
            {
                _productBestellingRepo.RemoveProductFromBestelling(bestelling, product);
            }
            bestelling.RemoveProductFromList(product);
            return true;
        }

        public void AddProductenFromDbToVoorraad()
        {
            Voorraad.AddProductenFromDb(_productRepo.GetProducten());
        }

        public List<Bestelling> GetBestellingen()
        {
            try
            {
                if (_bestellingen == null)
                {
                    GetBestellingenFromDb();
                }
                return _bestellingen;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Bestelling> GetAfgerekendeBestellingen()
        {
            try
            {
                if (_afgerekendeBestellingen == null)
                {
                    GetBestellingenFromDb();
                }
                return _afgerekendeBestellingen;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void GetBestellingenFromDb()
        {
            try
            {
                _bestellingen = new List<Bestelling>();
                _afgerekendeBestellingen = new List<Bestelling>();
                if (DBConnection)
                {
                    List<Bestelling> tijdelijkelijst = _bestellingRepo.GetAllBestellingen();
                    foreach (Bestelling bestelling in tijdelijkelijst)
                    {
                        if (bestelling.Betaald)
                        {
                            _afgerekendeBestellingen.Add(bestelling);
                        }
                        else
                        {
                            _bestellingen.Add(bestelling);
                        }
                    }
                    volgendBestellingNr = _bestellingen.Count + _afgerekendeBestellingen.Count;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private Voorraad GetVoorraad()
        {
            if (Voorraad == null)
            {
                return new Voorraad(DBConnection);
            }
            return Voorraad;
        }

        public List<Lid> GetLeden()
        {
            try
            {
                if (_leden == null)
                {
                    _leden = new List<Lid>();
                    _leden = _ledenRepo.GetAllLeden();
                    _leden.Sort((x, y) => x.Voornaam.CompareTo(y.Voornaam));
                }
                return _leden;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool BestellingAfrekenen(Bestelling bestelling, decimal bedrag)
        {
            bestelling.Afrekenen(bedrag, DateTime.Now);
            _afgerekendeBestellingen.Add(bestelling);
            BedragInKas += bestelling.BetaaldBedrag;
            _afgerekendeBestellingen.Sort((x, y) => -x.DatumBetaald.CompareTo(y.DatumBetaald));
            _bestellingen.Remove(bestelling);
            if (DBConnection)
            {
                _bestellingRepo.BetaalBestelling(bestelling);
            }
            return true;
        }

        public void AddProductToBestelling(Bestelling bestelling, Product product)
        {
            foreach (Bestelling b in _bestellingen)
            {
                if (b == bestelling)
                {
                    bool check = b.AddProductToList(product);
                    if (check)
                    {
                        if (DBConnection)
                        {
                            _productBestellingRepo.AddProductToBestelling(bestelling, product);
                            _productRepo.EditProduct(product);
                        }
                    }
                }
            }
        }

        public Product VindProduct(string naam)
        {
            Product product = Voorraad.VindProductOpNaam(naam);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public bool SetOpenstaandeBestellingen()
        {
            if (_bestellingen != null)
            {
                _bestellingen.Clear();
                return true;
            }
            return false;
        }

        public void FormulierInvullen(FormulierSoort soort, DateTime datum, string naam, string bankrekening, string reden, bool contant, string route, decimal bedrag, decimal geredenKm, string getekendDoor)
        {
            try
            {
                if (_formulieren != null)
                {
                    Formulier formulier = new Formulier(0, soort, datum, naam, bankrekening, reden, contant, route, geredenKm, bedrag, getekendDoor);
                    _formulieren.Add(formulier);
                    NeemBedragUitKas(bedrag);
                }
                else
                {
                    _formulieren = GetFormulieren();
                    FormulierInvullen(soort, datum, naam, bankrekening, reden, contant, route, geredenKm, bedrag, getekendDoor);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Lid GetLidByName(string name)
        {
            foreach (Lid lid in _leden)
            {
                if (lid.GetLidNaam() == name)
                {
                    return lid;
                }
            }
            return null;
        }

        public void AddNewProduct(int id, string naam, string soort, int voorraad, decimal ledenprijs, decimal prijs)
        {
            try
            {
                if (DBConnection)
                {
                    Product product = new Product(naam, soort, voorraad, ledenprijs, prijs);
                    _productRepo.AddProduct(product);
                    Voorraad.AddProduct(_productRepo.GetProductByName(product.Naam));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Product> GetLosseVerkopen()
        {
            if (_losseVerkopen == null)
            {
                _losseVerkopen = new List<Product>();
            }
            return _losseVerkopen;
        }

        public void AddLosseVerkoop(Product product)
        {
            if (DBConnection)
            {
                _productBestellingRepo.AddLosseVerkoop(product);
            }
            _losseVerkopen.Add(product);
        }

        public List<decimal> GetOmzetPerDag(DateTime weeknr)
        {
            List<decimal> dagOmzet = _omzetRepo.GetOmzetPerDag(weeknr);
            if (dagOmzet == null)
            {
                dagOmzet = new List<decimal>();
            }
            while (dagOmzet.Count < 6)
            {
                dagOmzet.Add(0);
            }
            return dagOmzet;
        }

        public List<decimal> GetOmzetPerWeek(DateTime maand)
        {
            List<decimal> weekOmzet = _omzetRepo.GetOmzetPerWeek(maand);
            if (weekOmzet == null)
            {
                weekOmzet = new List<decimal>();
            }
            while (weekOmzet.Count < 6)
            {
                weekOmzet.Add(0);
            }
            return weekOmzet;
        }

        public decimal GetOmzetPerJaar(DateTime year)
        {
            try
            {
                return _omzetRepo.GetOmzetPerJaar(year);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<string> GetLedenLog()
        {
            try
            {
                return _ledenLogRepo.GetLedenLog();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }
}
