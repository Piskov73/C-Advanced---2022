﻿using System;
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
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}")
                .AppendLine($"Manufactured by: {Brand}")
                .AppendLine($"Range: {Range} kilometers");

            return sb.ToString().TrimEnd();
        }
    }
}
