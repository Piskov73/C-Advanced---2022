﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            Rate = rate;
            Days = days;
            
        }
        // •Name: string
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //•	Type: string
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        //•	Rate: double
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        //•	Days: int
        private int ays;

        public int Days
        {
            get { return ays; }
            set { ays = value; }
        }

        //•	Hired: boolean - false by default
        private bool hired;

        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }
        //(name, type, rate, days). 

    
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-Renovator: {name}");
            sb.AppendLine($"--Specialty: {type}");
            sb.AppendLine($"--Rate per day: {rate} BGN");

            return sb.ToString().Trim();
        }







    }
}
