using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    internal class Ingredient
    {

        //	Name: string
        //•	Alcohol: int
        //•	Quantity: int
        public Ingredient(string name ,int alcohol,int quantity)
        {
            Name= name;
            Alcohol= alcohol;
            Quantity= quantity;
        }
        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
          StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Ingredient: {this. Name}");
            sb.AppendLine($"Quantity: {this.Quantity}");
            sb.AppendLine($"Alcohol: {this.Alcohol}");
            return sb.ToString().TrimEnd();
        }


    }
}
