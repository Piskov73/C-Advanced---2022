using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SkiRental
{
    internal class Ski
    {

        // •Manufacturer: string
        //•	Model: string
        //•	Year: int
        public Ski(string manufacturer,string model, int year)
        {
            Manufacturer= manufacturer;
            Model= model;
            Year= year;

        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {Year}";
        }
    }
}
