using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
		private List<Student> students;
		public Classroom(int capacity) 
		{
			Capacity= capacity;
			students = new List<Student>();
		}


		public List<Student> Students
        {
			get { return students; }
			set { students = value; }
		}

		public int Capacity { get; set; }

		public int 	Count { get { return students.Count; } }
		public string RegisterStudent(Student student)
		{
			if (Count < Capacity)
			{
				this.students.Add(student);
				return $"Added student {student.FirstName} {student.LastName}";

            }
			return "No seats in the classroom";

        }

		public string DismissStudent(string firstName, string lastName)
		{
			var filter=students.FirstOrDefault(x=>x.FirstName==firstName && x.LastName==lastName);
			if (filter != null)
			{
				students.Remove(filter);
				return $"Dismissed student {firstName} {lastName}";
            }
			return "Student not found";


        }

		public string GetSubjectInfo(string subject)
		{
			var studentsSubject=this.students.Where(x=>x.Subject==subject).ToList();
			if(studentsSubject.Count > 0)
			{
				StringBuilder sb=new StringBuilder();
				sb.AppendLine($"Subject: {subject}");
				sb.AppendLine("Students:");
				foreach (var student in studentsSubject)
				{
					sb.AppendLine($"{student.FirstName} {student.LastName}");
				}
				return sb.ToString().TrimEnd();
			}
			return "No students enrolled for the subject";

        }

		public int GetStudentsCount() { return this.Count; }
		public Student GetStudent(string firstName, string lastName)
		{
			return this.students.FirstOrDefault(x=>x.FirstName==firstName && x.LastName==lastName);	
		}

    }
}
