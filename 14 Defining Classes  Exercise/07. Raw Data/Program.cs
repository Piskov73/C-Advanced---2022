using System;
using System.Collections.Generic;


namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Car> filter = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //"{model}
                //{engineSpeed} {enginePower}
                //{cargoWeight} {cargoType}
                //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}
                //{tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string model = information[0];
                Engine engine = new Engine(int.Parse(information[1]), int.Parse(information[2]));
                Cargo cargo = new Cargo(int.Parse(information[3]), information[4]);
                Tires[] tires = new Tires[4]
                {
                    new Tires(double.Parse(information[5]),int.Parse(information[6])),
                    new Tires(double.Parse(information[7]),int.Parse(information[8])),
                    new Tires(double.Parse(information[9]),int.Parse(information[10])),
                    new Tires(double.Parse(information[11]),int.Parse(information[12])),
                };
                Car newCar = new Car(model, engine, cargo, tires);
                cars.Add(newCar);
            }

            string comands = Console.ReadLine();
            switch (comands)
            {
                case "fragile":
                    Fragile(cars);


                    break;

                case "flammable":

                    Flammable(cars);
                    break;

            }

        }

        static void Fragile(List<Car> cars)
        {
            //•	"fragile" - print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1.

            foreach (var car in cars)
            {
                if (car.Cargo.Type == "fragile")
                {
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }

        }

        static void Flammable(List<Car> cars)
        {
            //•	"flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.
            foreach (var car in cars)
            {
                if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}