using System;

namespace Logic.Classes
{
    public class Session
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public Session(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public Session(int id, string name, DateTime date) : this(name, date)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDateTime(DateTime date)
        {
            Date = date;
        }
    }
}
