using System;

// All classes need to be wrapped in a namespace
namespace IntroToDotNet.Syntax
{
	class Program
	{
		private const string _bulletPoint = "\u2022";

		static void Main()
		{
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.Clear(); // doing this after setting the background color will change the whole console background
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.Title = "C# Syntax Demo";

			ConsoleHelper.WriteHeading("Welcome to the C# Syntax Demo!");

			ConsoleHelper.Write("First, what is C#??");
			ConsoleHelper.Write($"{_bulletPoint} General-purpose object-oriented language");
			ConsoleHelper.Write($"{_bulletPoint} Uses semi-colons");
			ConsoleHelper.Write($"{_bulletPoint} Uses curly braces");
			ConsoleHelper.Write($"{_bulletPoint} Type safe");
			ConsoleHelper.Write($"{_bulletPoint} Easy");
			ConsoleHelper.Write($"{_bulletPoint} Cross platform");
			ConsoleHelper.Write($"{_bulletPoint} Flexible");
			ConsoleHelper.Write($"{_bulletPoint} Evolving");
			ConsoleHelper.Pause();

			Strings.Demo();

			DemoValueTypes();

			Dates.Demo();

			ConditionsSwitchesAndOperators.Demo();

			Arrays.Demo();

			Collectionz.Demo();

			Loops.Demo();

			Linqq.Demo();

			ErrorHandling.Demo();

			//TODO: add Functions (ref/val, out, optional), extension methods, classes, null coalescing

			ConsoleHelper.WriteAndPause("Well that is everything in a nutshell. Any final questions??");
		}

		private static void DemoValueTypes()
		{
			ConsoleHelper.WriteHeading("There are many different value types that can be used. Let's explore them.");

			Numbers.Demo();
			Booleans.Demo();
			Enums.Demo();

			ConsoleHelper.WriteAndPause("Any final questions about value types?");
		}
	}
}
