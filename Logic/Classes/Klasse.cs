using System;

namespace Logic.Classes
{
    public class Klasse
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public DateTime BeginLeeftijd { get; private set; }
        public DateTime EindLeeftijd { get; private set; }

        public Klasse(string naam, DateTime begin, DateTime eind)
        {
            Naam = naam;
            BeginLeeftijd = begin;
            EindLeeftijd = eind;
        }

        public Klasse(int id, string naam, DateTime begin, DateTime eind):this (naam, begin, eind)
        {
            Id = id;
        }

        public void SetBeginLeeftijd(DateTime begin)
        {
            BeginLeeftijd = begin;
        }

        public void SetEindLeeftijd(DateTime eind)
        {
            EindLeeftijd = eind;
        }
    }
}
