﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire(1,2.5),
                new Tire(1,2.5),
                new Tire(1,2.5),
            };

            Engine engine = new Engine(560, 6300);
            Car car = new Car("Lamborghini", "Urus", 2010,250,9,engine,tires);
        
        }
    }
}