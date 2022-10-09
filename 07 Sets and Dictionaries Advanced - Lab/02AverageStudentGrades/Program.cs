using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentGrades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var infoStudent = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string nameStudent = infoStudent[0];
                decimal grade = decimal.Parse(infoStudent[1]);
                AddStudent(studentGrades, nameStudent, grade);

            }

            //George -> 6.00 5.50 6.00 (avg: 5.83)
            foreach (var item in studentGrades)
            {
               
                Console.WriteLine($"{item.Key} -> {string.Join(' ',item.Value.Select(x=>$"{x:f2}"))} (avg: {item.Value.Average():f2})");
            }

            static void AddStudent(Dictionary<string, List<decimal>> studentGrades, string nameStudent, decimal grade)
            {
                if (!studentGrades.ContainsKey(nameStudent))
                {
                    studentGrades[nameStudent]=new List<decimal>();
                }
                studentGrades[nameStudent].Add(grade);
            }
        }
    }
}