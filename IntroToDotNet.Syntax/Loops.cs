using System.Collections.Generic;
using System.Linq;

namespace IntroToDotNet.Syntax
{
	public static class Loops
	{
		private static void SyntaxOnly()
		{
			//TODO: tidy up

			// Most commonly used is the for each using an array
			string[] array = new[] { "Hello", "World!", "Are", "We", "Having", "Fun", "Yet?" };
			foreach (string val in array)
			{
				ConsoleHelper.Write($"For each loop array value is {val}");
			}

			List<string> list = array.ToList(); // Oh, btw, you can cast an array to a list :)
			// It works the same way for lists too
			foreach (string val in list)
			{
				ConsoleHelper.Write($"For each loop list value is {val}");
			}

			// Next is a generic for loop using Length for the upper bound
			for (int i = 0; i < array.Length; i++)
			{
				ConsoleHelper.Write($"For loop array value is {array[i]}");
			}

			// Again, the same works for lists, but we use Count as the upper bounds
			for (int i = 0; i < list.Count; i++)
			{
				ConsoleHelper.Write($"For loop list value is {list[i]}");
			}

			// Then there is a while loop. These are not used often, but when you do, 
			// be careful you don't make it an endless loop :)
			int index = 0;
			while (index < list.Count)
			{
				ConsoleHelper.Write($"While loop list value is {list[index]}");
				index++;
			}

			// Then finally there is the do while loop. Much the same as the while loop 
			// but the condition is at the end
			index = 0;
			do
			{
				ConsoleHelper.Write($"Do while loop list value is {list[index]}");
				index++;
			} while (index < list.Count);
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("Let's explore the world of loops!");

			//TODO: add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}