using System;
using System.Collections.Generic;
using System.Text;

namespace _088Threeuple
{
    public class Threeuple<T1,T2,T3>
    {
        public T1 Threeuple1 { get; set; }
        public T2 Threeuple2 { get; set; }
        public T3 Threeuple3 { get; set; }
        public override string ToString()
        {
            return $"{Threeuple1} -> {Threeuple2} -> {Threeuple3}";
        }
    }
}
