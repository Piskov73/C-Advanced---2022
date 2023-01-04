using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
       
        
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }
        private List<CPU> multiprocessor;

        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int cCapacity;

        public int Capacity
        {
            get { return cCapacity; }
            set { cCapacity = value; }
        }


        

        public int Count { get { return multiprocessor.Count; } }


        public void Add(CPU cpu)
        {
            if (Capacity == Count)
            {
                return;
            }
            multiprocessor.Add(cpu);
        }


        public bool Remove(string brand)
        {
            var filterBrand = multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (filterBrand == null)
            {
                return false;
            }
            multiprocessor.Remove(filterBrand);
            return true;
        }


        public CPU MostPowerful()
        {

            var filter = multiprocessor.OrderByDescending(x => x.Frequency).ToList();


            return filter[0];



        }




        public CPU GetCPU(string brand)
        {
            return multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }


        //public string Report()
        //{
        //    StringBuilder sb= new StringBuilder();
        //    sb.AppendLine($"CPUs in the Computer {model}:");


        //        foreach (var item in multiprocessor)
        //        {
        //            sb.AppendLine(item.ToString());
        //        }

        //    return sb.ToString().Trim();
        //}
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var cpu in this.multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
