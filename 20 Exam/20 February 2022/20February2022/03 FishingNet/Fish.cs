namespace FishingNet
{
    public class Fish
    {
        // •FishType: string
        //•	Length: double
        //•	Weight: double
        public Fish(string fishType,double lenght,double weight)
        { 
            FishType = fishType;
            Length= lenght;
            Weight = weight;


        }
       public string FishType { get; set; }
        public double Length { get; set; }

        public double Weight { get; set; }
        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }

    }
}
