using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        //•	Name: string
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //•	NeededRenovators: int

        private int neededRenovators;

        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }


        //•	Project: string
        private string project;

        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public int Count { get { return renovators.Count; } }
        public string AddRenovator(Renovator renovator)
        {
            if (String.IsNullOrEmpty(renovator.Name) || String.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if(this.Count== neededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350.0)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";

        }
        public 	bool RemoveRenovator(string name)
        {
            Renovator renovator=renovators.FirstOrDefault(x => x.Name == name);
            return renovators.Remove(renovator);
        }
        public 	int RemoveRenovatorBySpecialty(string type)
        {
           
            List<Renovator> filterRenovator=renovators.Where(x=> x.Type != type).ToList();
             
            int countRemovedRenovators=renovators.Count-filterRenovator.Count;
            renovators = filterRenovator;
            return countRemovedRenovators;
        }
        public 	Renovator HireRenovator(string name)
        {
            Renovator renovator=renovators.FirstOrDefault(x=> x.Name == name);
            if(renovator!=null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }
        public 	List<Renovator> PayRenovators(int days)
        {
            List<Renovator> filter=renovators.Where((x) => x.Days >= days).ToList();
            return filter;
        }

        public string Report()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Renovators available for Project {project}:");

            List<Renovator> filter=renovators.Where(x=>x.Hired==false).ToList();
            foreach(Renovator r in filter)
            {
                sb.AppendLine(r.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
