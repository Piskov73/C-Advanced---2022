using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
       
        private List<Employee> employees;
        public Bakery(string name,int capacity)
        {
            Name= name;
            Capacity= capacity;
            Employees= new List<Employee>();
        }
        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return employees.Count; } }
        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee remuvOfName=employees.FirstOrDefault(x => x.Name==name);
            if (remuvOfName != null)
            {
                employees.Remove(remuvOfName);
                return true;
            }

            return false;
        }
        public Employee GetOldestEmployee()
        {
            int filterOldAge=employees.Max(x => x.Age);
            return employees.FirstOrDefault(x=>x.Age==filterOldAge);
        }
        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault((x)=>x.Name==name);
        }
        public string 	Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var emploee in employees)
            {
                sb.AppendLine(emploee.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
