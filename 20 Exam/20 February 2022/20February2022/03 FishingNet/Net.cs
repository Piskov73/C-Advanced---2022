using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
       
          private List<Fish> fish;
    
        public Net(string material,int capasity) 
        { 
            Material= material;
            Capacity= capasity;
            fish = new List<Fish>();
        }


        public List<Fish> Fish
        {
            get { return fish; }
            set { fish = value; }
        }


  
        public string Material { get; set; }    
       
        public int Capacity { get; set; }
      
        public int Count { get { return fish.Count; } }

      

        public 	string AddFish(Fish fish)
        {

            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if(Count==this.Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";

        }

        public 	bool ReleaseFish(double weight)
        {
            Fish remuveWeinght=this.Fish.FirstOrDefault(fishs=> fishs.Weight == weight);

            if (remuveWeinght != null)
            {
                this.fish.Remove(remuveWeinght);
                return true;
            }
            return false;
        }

        public 	Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(x=>x.FishType == fishType);
        }

        public 	Fish GetBiggestFish()
        {
            Fish max = this.Fish.First();
            foreach (var item in this.Fish)
            {
                if (item.Length > max.Length)
                {
                    max = item;
                }
            }
            return max; 
            //var longestFish = this.fish.Max(e => e.Length);
            //var fish = this.fish.FirstOrDefault(e => e.Length == longestFish);
            //return fish;
        }

        public string	Report()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine("Into the cast net:");
            foreach (var item in this.Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
