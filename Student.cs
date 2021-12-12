namespace SchoolManagementSystem
{
	public class Student
	{
		public int StudentId;
		public string Name;
		public string Surname;
		public int Age;

		public Student(string name, string surname, int age) : this (1, name, surname, age)
		{
			Name = name;
			Surname = surname;
			Age = age;
		}

		public Student(int studentId, string name, string surname, int age)
		{
			StudentId = studentId;
			Name = name;
			Surname = surname;
			Age = age;
		}

	}
}
