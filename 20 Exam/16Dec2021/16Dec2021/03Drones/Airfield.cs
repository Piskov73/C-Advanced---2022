using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        //•	Name: string
        //•	Capacity: int
        //•	LandingStrip - double
        private HashSet<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new HashSet<Drone>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public IReadOnlyCollection<Drone> Drones { get { return this.drones; } }
        public int Count => this.drones.Count;
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand)
                || !(drone.Range >= 5 && drone.Range <= 15))
            {
                return "Invalid drone.";
            }
            if (Count == this.Capacity)
            {
                return "Airfield is full.";
            }
            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public 	bool RemoveDrone(string name)
        {
            var filterRemuve=this.drones.FirstOrDefault(drones => drones.Name == name);
            if (filterRemuve != null)
            {
                this.drones.Remove(filterRemuve);
                return true;
            }
            return false;
        }
        public	int RemoveDroneByBrand(string brand)
        {
            var filterRemuve=this.drones.Where(drones => drones.Brand != brand).ToHashSet();
            int remuvDrons=Count-filterRemuve.Count;
            this.drones=filterRemuve;
            return remuvDrons;
        }
        public 	Drone FlyDrone(string name)
        {
            var flyDrone=this.drones.FirstOrDefault(drones=>drones.Name == name);
            if(flyDrone != null)
            {
                flyDrone.Available = true;
            }
            return flyDrone;
        }
        public	List<Drone> FlyDronesByRange(int range)
        {
            var flyDronesByRange=this.drones.Where(drones=>drones.Range >= range).ToList();
            if (flyDronesByRange.Count == 0) return null;
            return flyDronesByRange;
        }
        public string 	Report()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var dron in drones)
            {
                if(dron.Available==true) 
                sb.AppendLine(dron.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
