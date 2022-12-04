using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Data_Structures
{
    internal class CustomQueue
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;
        public CustomQueue()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }
        public 	void Enqueue(int element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.items[this.Count]= element;
            this.count++;
        }
        public int Dequeue()
        {
                      
                if (this.count == 0)
                {
                    throw new InvalidOperationException("CustomQueue is empti");
                }
            
            int first = this.items[0];
            Shift();
            this.count--;
            if (this.count == this.items.Length)
            {
                Shrinkage();
            }
            return first;
        }
        public 	int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empti");
            }
            return this.items[0];
        }
        public 	void Clear()
        {
            this.items=new int[InitialCapacity];
            this.count=0;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
        private void Resize()
        {
            int[] copy=new int[this.count*2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void Shift()
        {
            int[] copy = new int[this.Count];
            for (int i = 0; i < this.count-1; i++)
            {
                copy[i] = this.items[i + 1];
            }
            this.items = copy;
        }
        private void Shrinkage()
        {
            int[] copy =new int[this.count / 2];

            for (int i = 0; i < this.count; i++)
            {
                copy[i] = this.items[i];

            }
            this.items = copy;
        }
    }
}
