using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string species,string diet,double weight, double length )
        {
            Species= species;
            Diet= diet;
            Weight= weight;
            Length= length;
        }

        //•	Species – string
        public string Species { get; set; }
        //•	Diet – string
        public string Diet { get; set; }
        //•	Weight – double
        public double Weight { get; set; }
        //•	Length – double
        public double Length { get; set; }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.Append($"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.");

            return sb.ToString().TrimEnd();
        }


    }
}
