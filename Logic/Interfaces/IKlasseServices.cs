using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IKlasseServices
    {
        Klasse GetKlasseById(int id);
        List<Klasse> GetKlasses();
        void AddKlasse(Klasse klasse);
        void EditKlasse(Klasse klasse);
        void RemoveKlasse(Klasse klasse);
    }
}
