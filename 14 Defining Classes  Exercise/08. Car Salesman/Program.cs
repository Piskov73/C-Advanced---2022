using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] newEngine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddNewEngine(newEngine, engines);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] newCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddCar(newCar, cars, engines);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }



        static void AddNewEngine(string[] engine, Dictionary<string, Engine> engines)
        {
            //"{model} {power} {displacement} {efficiency}"
            if (engine.Length == 2)
            {
                engines.Add(engine[0], new Engine(engine[0], int.Parse(engine[1])));
            }
            else if (engine.Length == 3)
            {
                var isNumeric = int.TryParse(engine[2], out _);
                if (isNumeric)
                {
                    engines.Add(engine[0], new Engine(engine[0], int.Parse(engine[1]), int.Parse(engine[2])));
                }
                else
                {
                    engines.Add(engine[0], new Engine(engine[0], int.Parse(engine[1]), engine[2]));
                }
            }
            else
            {
                engines.Add(engine[0], new Engine(engine[0], int.Parse(engine[1]), int.Parse(engine[2]), engine[3]));
            }
        }

        static void AddCar(string[] car, List<Car> cars, Dictionary<string, Engine> engines)
        {
            string model = car[0];
            Engine newEngine = engines[car[1]];

            //"{model} {engine} {weight} {color}".
            if (car.Length == 2)
            {
                cars.Add(new Car(model,newEngine));
            }
            else if (car.Length == 3)
            {
                var isNumeric = int.TryParse(car[2], out _);

                if (isNumeric)
                {
                    cars.Add(new Car(model, newEngine, int.Parse(car[2])));
                }
                else
                {
                    cars.Add(new Car(model, newEngine,  car[2]));
                }
            }
            else
            {
                cars.Add(new Car(model, newEngine, int.Parse(car[2]), car[3]));
            }
                
        }
    }
}