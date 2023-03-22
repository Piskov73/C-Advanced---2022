using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {

        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        IReadOnlyCollection<Shoe> Shoes => shoes;
        public int Count => shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (this.Count < this.StorageCapacity)
            {
                this.shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return "No more space in the storage room.";

        }
        public int RemoveShoes(string material)
        {

            List<Shoe> filter = this.shoes.Where(m => m.Material.ToLower() != material.ToLower()).ToList();
            int remuvNumb = 0;
            remuvNumb = this.Count - filter.Count;
            this.shoes = filter;
            return remuvNumb;

        }
        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> filter = this.shoes.Where(t => t.Type.ToLower() == type.ToLower()).ToList();

            return filter;

        }
        public Shoe GetShoeBySize(double size)
        {
            return this.shoes.FirstOrDefault(sh => sh.Size == size);
        }
        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            List<Shoe> filter = this.shoes.Where(x => x.Size == size && x.Type.ToLower() == type.ToLower()).ToList();

            if (filter.Count > 0)
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var item in filter)
                {
                    sb.AppendLine(item.ToString());
                }
                return sb.ToString().TrimEnd();
            }
            return "No matches found!";

        }

    }
}
