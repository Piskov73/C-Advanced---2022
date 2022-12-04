using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Data_Structures
{
    internal class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;
        public CustomStack()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }
        public int Count
        {
            get { return this.count; }
        }
        public void Push(int element)
        {
            if (this.count == this.items.Length)
            {
                Resize();
            }
            this.items[this.count] = element;
            this.count++;
        }
        private void Resize()
        {
            int[] copy = new int[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = items[i];

            }
            this.items = copy;
        }
        public int Pop()
        {
            if(this.count==0)
            {
                throw new InvalidOperationException("CustomStack is empti");
            }
            int last = this.items[this.count-1];
            this.items[this.count-1] = 0;
            this.count--;
            if (this.count == this.items.Length)
            {
                Shrinkage();
            }
            return last;
        }
        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("CustomStack is empti");
            }
            
            return this.items[this.count-1];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
        private void Shrinkage()
        {
            int[] copy = new int[this.count / 2];

            for (int i = 0; i < this.count; i++)
            {
                copy[i] = this.items[i];

            }
            this.items = copy;
        }
    }
}
