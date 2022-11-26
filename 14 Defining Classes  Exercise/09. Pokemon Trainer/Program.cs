using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                AddTrainer(comand, trainers);


                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            string element = Console.ReadLine();
            while (element != "End")
            {
                Tournament(element, trainers);

                element = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.CollectionPokemon.Count}");
            }

        }



        static void AddTrainer(string[] comand, Dictionary<string, Trainer> trainers)
        {
            string trainerName = comand[0];
            string pokemonName = comand[1];
            string pokemonElement = comand[2];
            int pokemonHealth = int.Parse(comand[3]);

            Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);


            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = new Trainer();
                trainers[trainerName].Name = trainerName;
            }
            trainers[trainerName].CollectionPokemon.Add(pokemonName, newPokemon);



        }

        static void Tournament(string element, Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
               var pokemons= trainer.Value.CollectionPokemon;
                bool flag = true;

                foreach (var pokemon in pokemons)
                {
                    if (pokemon.Value.Element == element)
                    {
                        trainer.Value.Badges++;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    foreach (var pokemon in pokemons)
                    {
                        pokemon.Value.Health -= 10;
                        if (pokemon.Value.Health <= 0)
                        {
                            pokemons.Remove(pokemon.Key);
                        }
                    }
                }
            }
        }
    }
}