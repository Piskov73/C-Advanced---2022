using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace VetClinic
{
    internal class Clinic
    {
        private List<Pet> collection;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            collection = new List<Pet>();
        }
        public List<Pet> Collection
        {
            get { return collection; }
            set { collection = value; }
        }

        public int Capacity { get; set; }

        public int Count => collection.Count;

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                collection.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet remuvName=collection.FirstOrDefault(x => x.Name == name);
            if (remuvName != null)
            {
                collection.Remove(remuvName);
                return true;
            }

            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return collection.FirstOrDefault(x=>x.Name== name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            int oldAge=collection.Max(x=>x.Age);
            return collection.FirstOrDefault(x=>x.Age==oldAge);
        }
        public string	GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in collection)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().Trim();
        }
    }
}
