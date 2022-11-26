using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //•	Make – VW
        //•	Model – Golf
        //•	Year – 2025
        //•	FuelQuantity – 200
        //•	FuelConsumption – 10

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model,int year):this()
        {
            Make = make;
            Model=model;
            Year=year;
        }
        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption):this(make,model,year)
        {
          FuelQuantity=fuelQuantity;
            FuelConsumption=fuelConsumption;
        }

        private string make;
        public string Make { get { return make; } set { make = value; } }

       
        private string model;
        public string Model { get { return model; } set { model = value; } }

        
        private int year;
        public int Year { get { return year; } set { year = value; } }

        
        private double fuelQuantity;
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        
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

            
            st.AppendLine($"Make: {this.Make}");
          
            st.AppendLine($"Model: {this.Model}");
            
            st.AppendLine($"Year: {this.Year}");
           
            st.AppendLine($"Fuel: {this.FuelQuantity:F2}");

            return st.ToString();
        }

    }
}
