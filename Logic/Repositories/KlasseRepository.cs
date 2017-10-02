using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class KlasseRepository
    {
        private IKlasseServices _klasseServices;
        public KlasseRepository(IKlasseServices klasseServices)
        {
            _klasseServices = klasseServices;
        }
        public Klasse GetKlasseById(int id)
        {
            return _klasseServices.GetKlasseById(id);
        }

        public List<Klasse> GetKlasses()
        {
            return _klasseServices.GetKlasses();
        }

        public void AddKlasse(Klasse klasse)
        {
            _klasseServices.AddKlasse(klasse);
        }

        public void EditKlasse(Klasse klasse)
        {
            _klasseServices.EditKlasse(klasse);
        }

        public void RemoveKlasse(Klasse klasse)
        {
            _klasseServices.RemoveKlasse(klasse);
        }
    }
}
