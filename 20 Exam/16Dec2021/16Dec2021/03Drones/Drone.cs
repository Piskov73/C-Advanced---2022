using System;
using System.Text;
using System.Xml.Linq;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }
        // •	Name: string
        public string Name { get; set; }
        //•	Brand: string
        public string Brand { get; set; }
        //•	Range: int
        public int Range { get; set; }

        //•	Available: boolean - true by default
        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // Drone: {name}
            sb.AppendLine($"Drone: {this.Name}");
            // Manufactured by: { brand}
            sb.AppendLine($"Manufactured by: {this.Brand}");
            // Range: { range} kilometers
            sb.AppendLine($"Range: {this.Range} kilometers");

            return sb.ToString().TrimEnd();

        }




    }
}
