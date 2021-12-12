using System;

namespace SchoolManagementSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			StartMainAppFunctionallity();
		}

		public static void StartMainAppFunctionallity()
		{
			School school = Start();
			if (school != null)
			{
				ManageSchool(school);
			}
			else
			{
				StartMainAppFunctionallity();
			}
		}

		public static School Start()
		{
			Console.WriteLine("Please enter your school name");
			string newSchoolName = Console.ReadLine();
			if (newSchoolName.Length != 0)
			{
				School newSchool = new School(newSchoolName);
				Console.WriteLine($"School {newSchool.SchoolName} successfully created!");
				return newSchool;
			}
			else return null;
		}

		public static void ManageSchool(School school)
		{
			while (true)
			{
				Console.WriteLine($"Do you want to browse all students in {school.SchoolName}? Enter \"Yes\" or \"No\".");
				string answer = Console.ReadLine();
				if (answer.ToLower().Contains("yes"))
				{
					if (school.Students == null || school.Students.Count == 0)
					{
						school.SchoolDoesNotHaveStudents(school);
					}
					else
					{
						school.BrowseAllStudents(school);
					}
				}
				else if (answer.ToLower().Contains("no"))
				{
					Console.WriteLine("Do you want to quit the app? Enter \"Yes\" or \"No\".");
					answer = Console.ReadLine();
					QuitApp(answer);
				}
				else
				{
					Console.WriteLine("You didn't answer the question!");
					ManageSchool(school);
				}
			}
		}

		internal static void AddOrDeleteStudents()
		{
			throw new NotImplementedException();
		}

		public static void QuitApp(string answer)
		{
			if (answer.ToLower().Contains("yes"))
			{
				throw new NotImplementedException();
			}
			else if (answer.ToLower().Contains("no"))
			{
				StartMainAppFunctionallity();
			}
			else
			{
				Console.WriteLine("You didn't answer the question!");
				Console.WriteLine("Do you want to quit the app? Enter \"Yes\" or \"No\".");
				answer = Console.ReadLine();
				QuitApp(answer);
			}
		}
	}
}
