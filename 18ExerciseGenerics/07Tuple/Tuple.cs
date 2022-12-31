using System;
using System.Collections.Generic;
using System.Text;

namespace _07Tuple
{
    internal class Tuple<T1,T2>
    {
        public  T1 FirstTuple{ get; set; }
        public T2 SecondTuple { get; set;}

        public override string ToString()
        {
            return $"{FirstTuple} -> {SecondTuple}";
        }
    }
}
