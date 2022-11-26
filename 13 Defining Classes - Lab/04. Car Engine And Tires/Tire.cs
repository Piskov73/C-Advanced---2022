using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year,double pressure)
        {
            this.Year=year;
            this.Pressure = pressure;
        }

        //•	year: int

        private int year;
        public int Year { get { return year; } set { year = value; } }

        //•	pressure: double

        private double pressure;
        public double Pressure { get { return pressure; } set { pressure = value; } }

    }
}
