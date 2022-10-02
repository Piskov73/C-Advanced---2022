using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //{, }, (, ), [   , ]. 
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> brackets = new Stack<char>();

            bool end = true;

            foreach (var ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    brackets.Push(ch);
                    
                }
               else if ((brackets.Count>0)&&(brackets.Peek() == '(' && ch == ')'
                   || brackets.Peek() == '{' && ch == '}'
                   || brackets.Peek() == '[' && ch == ']'))
                {
                    brackets.Pop();
                }
                else
                {
                    end = false;
                    break;
                }
            }
            if (end && brackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
