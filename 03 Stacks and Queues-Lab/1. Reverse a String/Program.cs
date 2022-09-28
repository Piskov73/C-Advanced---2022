using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input=Console.ReadLine().ToCharArray();
            
            Stack<char> stringReverse=new Stack<char>();
            foreach (var ch in input)
            {
                stringReverse.Push(ch);
            }
            while (stringReverse.Count>0)
            {
                Console.Write(stringReverse.Pop());
            }
        }
    }
}
