﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        //private string brand;
        //private int cores;
        //private double frequency;

        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        //public override string ToString()
        //{

        //    StringBuilder sb = new StringBuilder();
        //    //         {brand} CPU:
        //    //        Cores: { cores}
        //    //        Frequency: { frequency} GHz
        //    sb.AppendLine($"{Brand} CPU:");
        //    sb.AppendLine($"Cores: {Cores}");
        //    sb.AppendLine($"Frequency: {Frequency:f1} GHz");

        //    return sb.ToString().Trim();

        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Brand} CPU:");
            sb.AppendLine($"Cores: {this.Cores}");
            sb.AppendLine($"Frequency: {this.Frequency:F1} GHz");

            return sb.ToString().TrimEnd();
        }


    }
}
