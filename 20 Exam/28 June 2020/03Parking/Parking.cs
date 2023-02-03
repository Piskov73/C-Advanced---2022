using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    internal class Parking
    {
        private List<Car> collection;
        public Parking(string type,int capacity)
        {
            Type= type;
            Capacity= capacity;
            collection = new List<Car>();
        }
        public List<Car> Collection
        {
            get { return collection; }
            set { collection = value; }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count=> collection.Count;
        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                collection.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var remove=collection.FirstOrDefault(x=>x.Manufacturer==manufacturer&&x.Model==model);
            if(remove!=null)
            {
                collection.Remove(remove);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if(Count==0) return null;
            int year=collection.Max(x=>x.Year);
            return collection.FirstOrDefault(x=>x.Year==year);
        }

        public Car GetCar(string manufacturer, string model)
        {
            var car = collection.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }

        public string 	GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach(Car car in collection) 
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
