using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {

        //•	Name: string
        //•	Capacity: int
        private List<Racer> collection;
        public Race(string name,int capasity)
        {
            Name= name;
            Capacity= capasity;
            collection= new List<Racer>();
        }
        public List<Racer> Collection
        {
            get { return collection; }
            set { collection = value; }
        }

        public string Name { get; set; }    
        public int Capacity { get; set; }

        public int Count { get { return collection.Count; } }

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                collection.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            var remuve =collection.FirstOrDefault(x => x.Name == name);
            if (remuve != null)
            {
                collection.Remove(remuve);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            int old = collection.Max(x => x.Age);
            return collection.FirstOrDefault(x=>x.Age == old);
        }
        public Racer GetRacer(string name)
        {
            return collection.FirstOrDefault(x=>x.Name== name);
        }
        public Racer GetFastestRacer()
        {
            int filter = collection.Max(x => x.Car.Speed);
            return collection.FirstOrDefault(x=>x.Car.Speed == filter);
        }
        public string 	Report()
        {
            StringBuilder sb = new StringBuilder();
            //Racers participating at {RaceName}:
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd() ;
        }

    }
}
