using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        // •	Name
        //•	Number of badges
        //•	A collection of pokemon



        public Trainer()
        {
            this.Badges = 0;
            this.CollectionPokemon = new Dictionary<string, Pokemon>();
        }

        public string Name { get; set; }    
        public int Badges { get; set; }
       public Dictionary<string,Pokemon> CollectionPokemon { get; set; }

        

    }
}
