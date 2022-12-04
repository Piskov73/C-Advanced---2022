using System;


namespace CustomDataStructures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }
        public int Count { get; private set; }

        public void Add(int element)
        {
            if (this.Count == items.Length)
            {
                Resize();
            }

            this.items[this.Count] = element;
            Count++;
        }
        public void Resize()
        {
            int[] copy = new int[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = items[i];

            }
            this.items = copy;
        }

        public int RemoveAt(int index)
        {

            if (CheckingIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int item = items[index];
            this.items[index] = default(int);
            this.Count--;
            Shift(index);
            if (this.Count == this.items.Length / 4)
            {
                Shrink();

            }

            return item;
        }

        public bool CheckingIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return true;
            }
            return false;
        }

        public void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        public void Shrink()
        {
            int[] copy = new int[this.Count * 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (CheckingIndex(firstIndex) || CheckingIndex(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void Insert(int index, int item)
        {
            if (index == this.Count)
            {
                Add(item);
                return;
            }
            CheckingIndex(index);
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            ShiftRight(index);
            items[index] = item;
            this.Count++;

        }
        public void ShiftRight(int index)
        {
            for (int i = this.items.Length - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public int this[int index]
        {
            get
            {
                CheckingIndex(index);
                return items[index];
            }

            set
            {
                CheckingIndex(index);
                items[index] = value;
            }
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
