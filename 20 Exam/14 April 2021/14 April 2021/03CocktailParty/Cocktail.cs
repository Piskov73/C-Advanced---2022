using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace CocktailParty
{
    internal class Cocktail
    {

        //•	Name: string
        //•	Capacity: int - the maximum allowed number of ingredients in the cocktail
        //•	MaxAlcoholLevel: int - the maximum allowed amount of alcohol in the cocktail

        private List<Ingredient> ingredients;

        public Cocktail(string name,int capacity,int maxAlcoholLevel)
        {
            Name= name;
            Capacity= capacity; 
            MaxAlcoholLevel= maxAlcoholLevel;

            ingredients= new List<Ingredient>();
        }


        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public string Name { get; set; }    
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int Count => ingredients.Count; //{ get { return ingredients.Count; } }
        public void Add(Ingredient ingredient)
        {
            Ingredient filter= this.Ingredients.FirstOrDefault(x=>x.Name==ingredient.Name);
            if (filter == null && this.Count < this.Capacity && this.MaxAlcoholLevel >= ingredient.Alcohol)
            {
                this.MaxAlcoholLevel-= ingredient.Alcohol;
                this.Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            Ingredient filter = this.Ingredients.FirstOrDefault(x => x.Name == name);
            if(filter != null)
            {
                this.MaxAlcoholLevel += filter.Alcohol;
                this.Ingredients.Remove(filter);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            return this.Ingredients.FirstOrDefault(x=>x.Name==name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlcohol=this.Ingredients.Max(x => x.Alcohol);
            return this.Ingredients.FirstOrDefault(x=>x.Alcohol==maxAlcohol&&maxAlcohol>0);
        }
        public int	 CurrentAlcoholLevel =>this.Ingredients.Sum(x=>x.Alcohol);
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in this.Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
