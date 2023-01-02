using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<char> vowelLetters = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToList());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToList());
            Dictionary<string, int> controlWords = new Dictionary<string, int>()
            {
              
                {"pear",0 },
                {"flour",0 },
                {"pork",0 },
                {"olive",0 }
              
            };
            int count = 0;
           
            List<char> pears = new List<char>("pear".ToList());
            List<char> flours = new List<char>("flour".ToList());
            List<char> porks = new List<char>("pork".ToList());
            List<char> olives = new List<char>("olive".ToList());
            while (consonants.Count>0)
            {
                char vowel = vowelLetters.Dequeue();
                vowelLetters.Enqueue(vowel);
                char cons=consonants.Pop();
                if (pears.Contains(vowel) || pears.Contains(cons))
                {
                    if(pears.Contains(vowel))
                    {
                        pears.Remove(vowel);
                    }
                    if (pears.Contains(cons))
                    {
                        pears.Remove(cons);
                    }
                    if(pears.Count==0&&controlWords["pear"]==0)
                    {
                        count++;
                        controlWords["pear"]++;
                        
                    }  
                }
                if (flours.Contains(vowel) || flours.Contains(cons))
                {
                    if (flours.Contains(vowel))
                    {
                        flours.Remove(vowel);
                    }
                    if (flours.Contains(cons))
                    {
                        flours.Remove(cons);
                    }
                    if (flours.Count == 0 && controlWords["flour"] == 0)
                    {
                        count++;
                        controlWords["flour"]++;
                        
                    }
                }
                if (porks.Contains(vowel) || porks.Contains(cons))
                {
                    if (porks.Contains(vowel))
                    {
                        porks.Remove(vowel);
                    }
                    if (porks.Contains(cons))
                    {
                        porks.Remove(cons);
                    }
                    if (porks.Count == 0 && controlWords["pork"] == 0)
                    {
                        count++;
                        controlWords["pork"]++;
                        
                    }
                }
                if (olives.Contains(vowel) || olives.Contains(cons))
                {
                    if (olives.Contains(vowel))
                    {
                        olives.Remove(vowel);
                    }
                    if (olives.Contains(cons))
                    {
                        olives.Remove(cons);
                    }
                    if (olives.Count == 0 && controlWords["olive"] == 0)
                    {
                        count++;
                        controlWords["olive"]++;
                       
                    }
                }
            }

            Console.WriteLine($"Words found: {count} ");

            foreach (var word in controlWords.Where(x=>x.Value>0))
            {
                Console.WriteLine(word.Key);
            }




        }
    }
}
