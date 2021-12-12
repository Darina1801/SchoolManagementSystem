using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem
{
	public class School
	{
		public string SchoolName;
		public List<Student> Students;
		public int YearOfOpening;

		public School(string schoolName) : this (schoolName, null)
		{ }

		public School(string schoolName, List<Student> students) : this (schoolName, students, -1)
		{ }

		public School(string schoolName, List<Student> students, int yearOfOpening)
		{
			SchoolName = schoolName;
			Students = students;
			YearOfOpening = yearOfOpening;
		}

		public void BrowseAllStudents(School school)
		{
			Console.WriteLine("{0, - 10} {1, - 10} {2, -10}", "Surname", "Name", "Age");
			for (int i = 0; i < school.Students.Count; i++)
			{
				Console.WriteLine("{0, - 10} {1, - 10}", school.Students[i].Surname, school.Students[i].Name);
			}
			Program.AddOrDeleteStudents();
		}

		public void SchoolDoesNotHaveStudents(School school)
		{
			Console.WriteLine("You don't have any students at your school yet. Do you want to add them? Enter \"Yes\" or \"No\".");
			string answer = Console.ReadLine();
			if (answer.ToLower().Contains("yes"))
			{
				school.AddStudents(school);
			}
			else if (answer.ToLower().Contains("no"))
			{
				Console.WriteLine("Do you want to quit the app? Enter \"Yes\" or \"No\".");
				answer = Console.ReadLine();
				Program.QuitApp(answer);
			}
			else
			{
				Console.WriteLine("You didn't answer the question!");
				SchoolDoesNotHaveStudents(school);
			}
		}

		public void AddStudents(School school)
		{
			Console.WriteLine("Enter student's name");
			string name = Console.ReadLine();
			Console.WriteLine("Enter student's surname");
			string surname = Console.ReadLine();
			Console.WriteLine("Enter student's age");
			int age = Convert.ToInt32(Console.ReadLine());

			Student newStudent;

			if (school.Students == null || school.Students.Count == 0)
			{
				newStudent = new Student(name, surname, age);
				school.Students.Add(newStudent);
			}
			else
			{
				int studentId = school.Students.Count() + 1;
				newStudent = new Student(studentId, name, surname, age);
				school.Students.Add(newStudent);
			}

			Console.WriteLine($"New student {newStudent.Surname} {newStudent.Name} successfully added to school {school.SchoolName}!");
			Console.WriteLine("Do you want to add one more student to your school?");
			string answer = Console.ReadLine();
			if (answer.ToLower().Contains("yes"))
			{
				school.AddStudents(school);
			}
			else if (answer.ToLower().Contains("no"))
			{
				Console.WriteLine($"You have following students at your school {school.SchoolName}:");
				BrowseAllStudents(school);
			}
			else
			{
				Console.WriteLine("You didn't answer the question!");
				AddStudents(school);
			}
		}

		public void DeleteStudent(School school)
		{
			Console.WriteLine("Enter student's id");
			int id = Convert.ToInt32(Console.ReadLine());
			school.Students.Remove(school.Students.Find(x => x.StudentId == id));
		}
	}
}
