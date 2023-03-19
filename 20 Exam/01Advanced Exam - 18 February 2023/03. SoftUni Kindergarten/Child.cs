namespace SoftUniKindergarten
{
    public class Child
    {
        public Child(string firstName,string lastName,int age,string parentName,string contackNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.ParentName = parentName;
            this.ContactNumber= contackNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ParentName { get; set; }
        public string ContactNumber { get; set; }

        public override string ToString()
        {
            return $"Child: {FirstName} {LastName}, Age: {Age}, Contact info: {ParentName} - {ContactNumber}";
        }
    }
}
