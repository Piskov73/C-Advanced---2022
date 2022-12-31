using System;
using System.Collections.Generic;
using System.Text;

namespace _05CountMethodStrings
{
    public class Box<T> where T: IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public int Count(T input)
        {
            int count = 0;
            foreach (T item in Items) 
            {
                if (item.CompareTo(input) > 0)
                {
                    count++;
                }
            }
      

            return count;
        }
    }
}
