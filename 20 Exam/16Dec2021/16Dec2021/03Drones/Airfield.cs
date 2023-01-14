using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        // •	Name: string
        //•	Capacity: int
        //•	LandingStrip - double
        private List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public List<Drone> Drones
        {
            get { return drones; }
            set { drones = value; }
        }




        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }
            else if (drones.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";

        }

        public bool RemoveDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(x => x.Name == name);
            if (drone == null)
            {
                return false;
            }
            return drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            int numberOFRemovedDrones = 0;

            List<Drone> remuvedDrones = drones.Where(drone => drone.Brand != brand).ToList();

            numberOFRemovedDrones = Count - remuvedDrones.Count;
            drones = remuvedDrones;
            return numberOFRemovedDrones;
        }

        public Drone FlyDrone(string name)
        {
            Drone flyDrone = this.Drones.FirstOrDefault(x => x.Name == name);
            if (flyDrone == null)
            {
                return null;
            }
            flyDrone.Available = false;
            return flyDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var filter = this.Drones.Where(x => x.Range >= range && x.Available == true).ToList();
            foreach (var drone in filter)
            {
                drone.Available = false;
            }
            return filter;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var item in this.Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
