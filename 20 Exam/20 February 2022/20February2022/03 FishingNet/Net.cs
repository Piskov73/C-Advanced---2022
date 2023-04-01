using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
      
        public Net(string material,int capacity)
        {
            this.Material=material;
            this.Capacity=capacity;
            this.fish = new List<Fish>();
        }

        public string Material { get;set; }
        public int Capacity { get; set; }

        public IReadOnlyCollection<Fish> Fish => this.fish;

        public int Count => fish.Count;

        public 	string AddFish(Fish fish)
        {
            if(string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            if(fish.Length<=0||fish.Weight<=0)
            {
                return "Invalid fish.";
            }
            if(this.Count==this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public	bool ReleaseFish(double weight)
        {
            var filterRemuve=this.fish.FirstOrDefault(fish => fish.Weight<=weight);
            if(filterRemuve!=null)
            {
                this.fish.Remove(filterRemuve);
                return true;
            }
            return false;
        }
        public 	Fish GetFish(string fishType) =>this.fish.FirstOrDefault(f=>f.FishType==fishType);

        public 	Fish GetBiggestFish()
        {
            if(Count==0) return null;
            double maxLenght=this.fish.Max(fish => fish.Length);
            
            return this.fish.First(f=>f.Length==maxLenght);

           

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            //Into the {material}:
            sb.AppendLine($"Into the {Material}:");
            foreach(var fish in this.fish.OrderByDescending(f=>f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
