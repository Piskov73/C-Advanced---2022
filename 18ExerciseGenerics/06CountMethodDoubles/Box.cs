using System;
using System.Collections.Generic;
using System.Text;

namespace _06CountMethodDoubles
{
    public class Box<T> where T: IComparable<T>
    {
        public Box()
        {
            Elements= new List<T>();
        }
        public List<T> Elements { get; set; }
        public int Count(T compare)
        {
            int count = 0;

            foreach (T element in Elements)
            {
                if (element.CompareTo(compare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
