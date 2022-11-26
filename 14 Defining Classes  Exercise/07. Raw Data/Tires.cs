﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        //age and pressure.

        private double pressure;

        public Tires(double pressure, int age)
        {
            this.Pressure = pressure;

            this.Age = age;

        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
