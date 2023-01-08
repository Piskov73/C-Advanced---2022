using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
       
        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }
            //"herbivore" or "carnivore", 
            if ((animal.Diet == "herbivore") || (animal.Diet == "carnivore"))
            {
            }
            else
            {
                return "Invalid animal diet.";

            }
            if (animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;
            List<Animal> filter=  animals.Where(x=>x.Species!=species).ToList();
            count=animals.Count-filter.Count;
            this.animals=filter;
            return count;
        }

        public	List<Animal> GetAnimalsByDiet(string diet)
        {
            return animals.Where(x=>x.Diet==diet).ToList();
        }

        public 	Animal GetAnimalByWeight(double weight)
        {
            return animals.FirstOrDefault(x=>x.Weight==weight);
        }

        public 	string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var count = 0;
            foreach (var animal in animals)
            {
                if(animal.Length>=minimumLength&&animal.Length<=maximumLength)
                {
                    count++;
                }
            }
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
