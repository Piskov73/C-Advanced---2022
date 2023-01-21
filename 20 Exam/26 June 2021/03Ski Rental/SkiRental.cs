using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SkiRental
{
    internal class SkiRental
    {

        //•	Name: string
        //•	Capacity: int
        public SkiRental(string name,int capacity) 
        { 
            Name= name;
            Capacity= capacity;
            data=new List<Ski>();
        }


        private List<Ski> data;

        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
        }


        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }
        public void Add(Ski ski)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski remove=data.FirstOrDefault(x=>x.Manufacturer==manufacturer && x.Model==model);
            if (remove != null)
            {
                data.Remove(remove);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if(this.Count==0) return null;

            int newestSki = this.data.Max(x=>x.Year);

            return this.data.FirstOrDefault(x=>x.Year==newestSki);
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine($"The skis stored in {this.Name}:");
            foreach (var item in data)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString().Trim();
        }


    }
}
