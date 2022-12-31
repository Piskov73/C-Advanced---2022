using System;
using System.Collections.Generic;
using System.Text;

namespace _02BoxOfInteger
{
    public class Box<T>
    {


        public Box()
        {
            Items= new List<T>();
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
