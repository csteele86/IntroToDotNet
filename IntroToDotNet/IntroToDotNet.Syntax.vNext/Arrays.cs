using System;

namespace IntroToDotNet.Syntax.vNext
{
	public static class Arrays
	{
		private static void SyntaxOnly()
		{
			//TODO: Tidy up

			// An array can be created many different ways:
			// By defining an upper bound (long way). This can hold 3 values starting with the 0 index
			string[] longHandArray = new string[5] { "hello", "my", "name", "is", "Chris" };

			// Without defining an upper bound (shorter way). The upper bound is derived
			string[] shortHandArray = new string[] { "hello", "my", "name", "is", "Chris" };

			// Without defining a type on the right side of the equal sign (shortest way).
			string[] shortestHandArray1 = { "hello", "my", "name", "is", "Chris" };
			// Or use var
			var shortestHandArray2 = new[] { "hello", "my", "name", "is", "Chris" };

			// Less commonly used are multi-dimensional arrays
			// Creates a 2 x 3 array 
			int[,] multiDimensionArray1 = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };
			var multiDimensionArray2 = new[,] { { 1, 2, 3 }, { 1, 2, 3 } };

			// Even less commonly used are jagged arrays
			int[][] jaggedArray1 = new int[2][];
			jaggedArray1[0] = new[] { 1, 2 };

			// And if I didn't have a good reason to use multi-dimension or jagged arrays, 
			// we can finally create a multi-dimension jagged array
			int[,][] jaggedMultiDimensionArray = new int[2, 2][];
			jaggedMultiDimensionArray[0, 0] = new int[] { 1, 2 };

			// Back to reality!
			// We can get arrays by splitting a string too
			var commaDilemented = "1, 2, 3, 4, 5, 6,";
			var splitArray = commaDilemented.Split(',');

			// We can also write out/flatten an array quick and easy using string.join
			ConsoleHelper.Write($"The array values are '{string.Join("|", splitArray)}'");

			// Wait, what was with the spacing? Let's split the string again differently
			splitArray = commaDilemented.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			ConsoleHelper.Write($"The array values are '{string.Join("|", splitArray)}'");

			// You can also retrieve values in an array from an index
			var index0Value = splitArray[0];

			// Or set them for that matter
			ConsoleHelper.Write($"Index 0 value is '{splitArray[0]}'");
			splitArray[0] = "It's Changed!";
			ConsoleHelper.Write($"Now index 0 value is '{splitArray[0]}'");

			// This is how to check if an array contains values or not
			if (splitArray != null && splitArray.Length > 0)
			{
				ConsoleHelper.Write($"The array has {splitArray.Length} values!");
			}
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("Arrays are fun! This is how they are used:");
			
			// TODO: Add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}