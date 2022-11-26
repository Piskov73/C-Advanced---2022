using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        // •make: string
        private string make;
        public string Make { get { return make; } set { make = value; } }

        //•	model: string
        private string model;
        public string Model { get { return model; } set { model = value; } }
        //•	year: int
        private int year;
        public int Year { get { return year; } set { year = value; } }

    }
}
