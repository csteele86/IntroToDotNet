using System;

namespace IntroToDotNet.Syntax
{
	public static class ConditionsSwitchesAndOperators
	{
		private static void SyntaxOnly()
		{
			// TODO: Tidy up and expand on new switch features

			ConsoleHelper.Write(@"These are the various comparison operators:
==  equal
!=  not equal
>   greater than
<   less than
>=  greater than or equal
<=  less than or equal");

			// For demonstration purposes, we will randomize a number
			Random random = new Random();

			// Your typical >, >=, <, <=
			var isLessThan50 = false;
			int num = random.Next(100);
			if (num < 50)
			{
				isLessThan50 = true;
			}
			else if (num >= 50)
			{
				isLessThan50 = false;
			}

			// The % sign allow  to 
			int num2 = random.Next(100);
			if (num2 % 2 == 0)
			{
				ConsoleHelper.Write($"Number is an equal number: {num2}");
			}
			else
			{
				ConsoleHelper.Write($"Number must not be an equal number: {num2}");
			}

			ConsoleHelper.Write(@"These are the various conditional operators:
&&  logical AND
||  logical OR
!   logical NOT (often read as 'bang')
^   logical XOR (exclusive OR) See https://msdn.microsoft.com/en-us/library/zkacc7k1.aspx for more info on XOR");

			int num3 = random.Next(100);
			if (num3 >= 0 && num3 <= 20)
			{
				ConsoleHelper.Write($"Number is between 0 and 20");
			}
			else if ((num3 > 20 && num3 <= 30) || (num3 >= 70 && num3 <= 80) && !(num3 >= 90))
			{
				ConsoleHelper.Write($"Number is either between 21-30 or 70-80 and not greater than 90: {num3}");
			}
			else
			{
				ConsoleHelper.Write($"Number failed all conditions: {num3}");
			}

			ConsoleHelper.Write("Switch statements are just like if/else, but are preferred when there might be a lot of conditions");

			int num4 = random.Next(100);
			switch (num4)
			{
				case 1:
					ConsoleHelper.Write("We sure got lucky that the number was 1");
					break;
				case 40:
					ConsoleHelper.Write("We sure got lucky that the number was 40");
					break;
				case 55:
				case 67:
					ConsoleHelper.Write($"We sure got lucky that the number was 55 or 67 - {num4}");
					break;
				default:
					ConsoleHelper.Write($"Darn! We didn't get lucky. The number is {num4}");
					break;
			}
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("You can't have a program without conditions. What do they look like?");

			//TODO: add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}