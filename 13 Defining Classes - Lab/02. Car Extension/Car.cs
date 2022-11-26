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

        //•	fuelQuantity: double
        private double fuelQuantity;
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        //•	fuelConsumption: double
        private double fuelConsumption;
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - distance * this.fuelConsumption > 0)
            {
                this.fuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder st = new StringBuilder();

            // "Make: {this.Make}
            st.AppendLine($"Make: {this.Make}");
            // Model: { this.Model}
            st.AppendLine($"Model: {this.Model}");
            //  Year: { this.Year}
            st.AppendLine($"Year: {this.Year}");
            //  Fuel: { this.FuelQuantity:F2}
            st.AppendLine($"Fuel: {this.FuelQuantity:F2}");
                       
            return st.ToString();
        }

    }
}
