using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            Stack<int> stackInt = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackInt.Push(i);
                
                }
                else if (input[i] == ')')
                {
                    string output=input.Substring(stackInt.Peek(), i - stackInt.Pop()+1);
                    Console.WriteLine(output);
                }
            }
        }
    }
}
