using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;

        public ShoeStore(string name,int capacity)
        {
            Name=name;
            StorageCapacity=capacity;
            shoes = new List<Shoe>();
            
        }

            // •	Name – string
            //•	StorageCapacity – int
            //•	Shoes – List<Shoe>
            private string name;
      
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int storageCapacity;

        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }
              
        public int Count { get { return shoes.Count; } }

        public 	string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        public int RemoveShoes(string material)
        {
            List<Shoe>filter = shoes.Where(x=>x.Material!=material).ToList();

            int count = Count-filter.Count;
            shoes = filter;
            return count;
        }
        public 	List<Shoe> GetShoesByType(string type)
        {
            List <Shoe> filterType=shoes.Where(x=>x.Type.ToLower()==type.ToLower()).ToList();
            return filterType;
        }

        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe=shoes.FirstOrDefault(x=>x.Size==size);
            return shoe;
        }
        public 	string StockList(double size, string type)
        {
            List<Shoe> filters=shoes.Where(x=>x.Size==size&&x.Type==type).ToList();
            if (filters != null)
            {
                StringBuilder sb=new StringBuilder();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                //"Stock list for size {size} - {type} shoes:
                foreach (var item in filters)
                {
                    sb.AppendLine(item.ToString());
                }
                return sb.ToString().Trim();

            }

            return "No matches found!";
        }


    }
    
}
