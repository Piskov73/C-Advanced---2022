using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            int mealsCount = 0;


            while (meals.Count > 0 && calories.Count > 0)
            {


                string meal = meals.Dequeue();
                mealsCount++;
                int calorie = 0;
                switch (meal)
                {
                    //salad   350
                    case "salad":
                        calorie = 350;
                        break;
                    //soup    490
                    case "soup":
                        calorie = 490;
                        break;
                    //pasta   680
                    case "pasta":
                        calorie = 680;
                        break;
                    //steak   790

                    case "steak":
                        calorie = 790;
                        break;
                }

                int caloriesDey = calories.Pop()-calorie;
                if (caloriesDey > 0)
                {
                    calories.Push(caloriesDey);
                }
                if (caloriesDey < 0 && calories.Count > 0)
                {
                    int temp = calories.Pop() + caloriesDey;
                    calories.Push(temp);
                }


            }

            if (calories.Count > 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }


        }
    }
}
