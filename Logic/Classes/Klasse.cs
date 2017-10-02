using System;

namespace Logic.Classes
{
    public class Klasse
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public int BeginLeeftijd { get; private set; }
        public int EindLeeftijd { get; private set; }

        public Klasse(string naam, int begin, int eind)
        {
            Naam = naam;
            BeginLeeftijd = begin;
            EindLeeftijd = eind;
        }

        public Klasse(int id, string naam, int begin, int eind):this (naam, begin, eind)
        {
            Id = id;
        }

        public void SetBeginLeeftijd(int begin)
        {
            BeginLeeftijd = begin;
        }

        public void SetEindLeeftijd(int eind)
        {
            EindLeeftijd = eind;
        }
    }
}
