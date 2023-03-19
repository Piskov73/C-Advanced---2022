using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        //•	Name - string
        //•	Capacity - int 
        //•	Registry - List<Child>
        public Kindergarten(string name,int capacity) 
        { 
            this.Name = name;
            this.Capacity = capacity;
            this.Registry=new List<Child>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount => Registry.Count;
        public bool AddChild(Child child)
        {
            if (ChildrenCount < Capacity)
            {
                this.Registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string[] fulName=childFullName.Split(' ',System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = fulName[0];
            string lastName = fulName[1];
            var filterName=Registry.FirstOrDefault(x=>x.FirstName==firstName);
            if (filterName!=null) 
            { 
                if(filterName.LastName==lastName)
                {
                    Registry.Remove(filterName);
                    return true;
                }
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string[] fulName = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = fulName[0];
            string lastName = fulName[1];
            var filterName = Registry.FirstOrDefault(x => x.FirstName == firstName );
            if (filterName != null)
            {
                if (filterName.LastName == lastName)
                {
                   
                    return filterName;
                }
            }
            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in this.Registry.OrderByDescending(ch=>ch.Age).ThenBy(ch=>ch.LastName).ThenBy(ch=>ch.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
