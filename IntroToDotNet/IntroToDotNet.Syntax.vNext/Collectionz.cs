using System.Collections.Generic;
using System.Linq;

namespace IntroToDotNet.Syntax.vNext
{
	public static class Collectionz
	{
		private static void SyntaxOnly()
		{
			//TODO: Tidy up

			// Lists allow you to store a collection of any type you need to use

			// Like an array, you can create a list many different ways:
			// You can create empty lists
			List<int> myList = new List<int>();

			// Or you can populate it when you instantiate it
			myList = new List<int> { 2, 3, 4 };

			// Or you can use an array to initialize a list as well
			string[] numbers = "1, 2, 3, 4, 5, 6,".Split(',');
			List<string> myNumbers = new List<string>(numbers);

			// This is how you add more values to a list. It must be of the same type
			myList.Add(2);
			// This does not work
			//myList.Add("2");

			// You can remove an item based on an item in the list
			myNumbers.Remove("1");

			// You can also insert new items in a specific index
			myNumbers.Insert(0, "100");

			// This is how you would remove at a specified index
			myNumbers.RemoveAt(0);

			// This removes anything that contains '2'. The LINQ demo will describe this syntax later
			myNumbers.RemoveAll(c => c.Contains("2"));

			// You can retrieve a value based on an index too
			ConsoleHelper.Write($"The list value at index 0 is '{myNumbers[0]}'.");

			// This is how to see how many values are in the list
			ConsoleHelper.Write($"The list has '{myNumbers.Count}' values.");

			// This is how you determine if a list has values 
			if (myNumbers != null && myNumbers.Any())
			{
				ConsoleHelper.Write("The list has values!");
			}

			// This is how to clear a list 
			myNumbers.Clear();

			// Like the array, we can easily display the values of a list
			ConsoleHelper.Write($"The list contains the following values: {string.Join("|", myList)}");

			// You can also make changes to each item in the list by doing this. The LINQ demo will describe this syntax later
			myList.ForEach(item => ConsoleHelper.Write(item.ToString()));
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("Collections are commonly used and are super useful. This is how they are used:");

			//TODO: Add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}