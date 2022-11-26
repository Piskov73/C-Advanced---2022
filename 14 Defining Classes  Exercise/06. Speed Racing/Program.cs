using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car newCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(model, newCar);


            }

            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "End")
            {
                string carModel = comand[1];
                double amountOfKm = double.Parse(comand[2]);
                if (cars.ContainsKey(carModel))
                {
                    cars[carModel].Drive(amountOfKm);
                }


                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value.PrintCar());
            }
        }
    }
}
