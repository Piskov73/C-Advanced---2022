using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {

            participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }


        public List<Car> Participants
        {
            get { return participants; }
            set { participants = value; }
        }


        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count { get { return participants.Count; } }

        public void Add(Car car)
        {
            Car filter = participants.FirstOrDefault(x => x.LicensePlate == car.LicensePlate);
            if (filter == null && Count < this.Capacity && car.HorsePower <= this.MaxHorsePower)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car filterLicensePlate = this.participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (filterLicensePlate != null)
            {
                participants.Remove(filterLicensePlate);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {

            var filter = this.participants.Max(x => x.HorsePower);
            return this.participants.FirstOrDefault(x => x.HorsePower == filter);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in this.participants)
            {
                sb.AppendLine(item.ToString());
            }


            return sb.ToString().Trim();
        }


    }
}
