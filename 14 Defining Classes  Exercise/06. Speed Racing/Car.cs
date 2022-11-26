using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travellediDstance;
        
        public Car()
        {
            this.TravellediDstance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;

        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravellediDstance
        {
            get { return travellediDstance; }
            set { travellediDstance = value; }
        }


        public void Drive(double amountOfKm)
        {
            if (this.FuelAmount - this.FuelConsumptionPerKilometer * amountOfKm >= 0)
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * amountOfKm;
                this.TravellediDstance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }


        public string PrintCar()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravellediDstance}";
        }
    }
}
