using System.Collections.Generic;
using System.Linq;

namespace IntroToDotNet.Syntax
{
	public static class Linqq
	{
		private static void SyntaxOnly()
		{
			// LINQ stands for Language-Integrated Query essentially is a way to 
			// query collections using extension methods. Extension methods are 
			// a lot like they sound. They extend a type to provide additional 
			// functionality. LINQ will be your friend someday as it cuts down
			// on a lot of coding!

			List<Teacher> teachers = GetTeachers();

			// Say I want teachers who teach 9th grade and up. We can just do this.
			// The "=>" syntax is called a lambda expression; essentially it's shorthand for creating functions
			IEnumerable<Teacher> ninthGradeAndUp = teachers.Where(teacher => teacher.Grade >= 9);

			// Now let's make what we retrieved legible. We can use the Select method to retrieve a subset of the collection
			IEnumerable<string> legibleNinthGradeTeachers =
				ninthGradeAndUp.Select(teacher => $"{teacher.LastName}, {teacher.FirstName} - {teacher.Grade} grade");

			ConsoleHelper.Write($"These are the teachers 9th grade and up:\n{string.Join("\n", legibleNinthGradeTeachers)}");

			// We also have the ability to skip or take a specific amount.
			IEnumerable<Teacher> skipAndTakeTeachers = teachers.Skip(2).Take(3);

			// Please note that since we overrode the ToString method on the Teacher class, .NET will use the ToString 
			// method to get our custom value; otherwise it would use the fully qualified name - IntroToDotNet.Syntax.Teacher
			ConsoleHelper.Write($"These are the teachers we chose after skipping 2 and taking 3:\n{string.Join("\n", skipAndTakeTeachers)}");

			// Let's say we want to find a specific record in a collection. We would do this
			// This will return the default value of what you are looking for if not found
			Teacher specificTeacher = teachers.Where(teacher => teacher.Grade == 13).FirstOrDefault();
			// Or like this
			specificTeacher = teachers.FirstOrDefault(teacher => teacher.Grade == 13);
			// Or like this, but it will throw an exception if nothing is found
			specificTeacher = teachers.Where(teacher => teacher.Grade == 13).First();
			// Or like this
			specificTeacher = teachers.First(teacher => teacher.Grade == 13);

			ConsoleHelper.Write($"Specific teacher is {specificTeacher}");

			// We can use the DefaultIfEmpty which will use whatever you pass in the parameter if the
			// code encounters no values. 
			IEnumerable<Teacher> defaultIfEmpty = teachers.Where(teacher => teacher.Grade == 15)
				.DefaultIfEmpty(new Teacher());

			ConsoleHelper.Write($"No teachers were found who teaches 15th grade: {string.Join("\n", defaultIfEmpty)}");

			// Maybe you just need to know if values exist in the collection. You can do this
			bool valuesExist = teachers.Any();

			// You can do that with a condition as well.
			bool teachersExist = teachers.Any(teacher => teacher.Grade > 13);
			int teacherCount = teachers.Count(teacher => teacher.Grade > 13);
			ConsoleHelper.Write($"Are there any teachers teaching anything above 13th grade? {teachersExist}");

			// Another thing that is handy sometimes is easy casting.
			Teacher[] teachers2 = teachers.ToArray();
			List<Teacher> teachers3 = teachers2.ToList();
		}

		private static List<Teacher> GetTeachers()
		{
			return new List<Teacher>
			{
				new Teacher { FirstName = "Jane", LastName = "Doe", Grade =  3},
				new Teacher { FirstName = "John", LastName = "Snow", Grade =  12},
				new Teacher { FirstName = "Marvin", LastName = "Wolf", Grade =  6},
				new Teacher { FirstName = "Luke", LastName = "Carter", Grade =  5},
				new Teacher { FirstName = "Bernice", LastName = "Fox", Grade =  9},
				new Teacher { FirstName = "Christopher", LastName = "Steele", Grade =  13} // huh??
			};
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("LINQ?! What is that?? Let's explore.");

			//TODO: add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}