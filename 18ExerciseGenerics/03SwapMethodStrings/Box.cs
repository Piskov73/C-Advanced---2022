using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03SwapMethodStrings
{
    public class Box<T>
    {


        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public string Swap(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int[] index = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            T temp = Items[index[0]];
            Items[index[0]] = Items[index[1]];
            Items[index[1]] = temp;
            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
