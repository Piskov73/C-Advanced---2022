using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> textEditor = new Stack<string>();
            StringBuilder text = new StringBuilder();
            textEditor.Push(text.ToString());
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (comand[0])
                {
                    case "1":
                        text = text.Append(comand[1]);
                        textEditor.Push(text.ToString());
                        break;
                    case "2":
                        int remuveElement = int.Parse(comand[1]);
                        text = text.Remove(text.Length - remuveElement, remuveElement);
                        textEditor.Push(text.ToString());
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(comand[1]) - 1]);
                        break;
                    case "4":
                        text = new StringBuilder();
                        textEditor.Pop();
                        string temp = textEditor.Peek();
                      text=  text.Append(temp);
                        break;
                }
            }
        }
    }
}

