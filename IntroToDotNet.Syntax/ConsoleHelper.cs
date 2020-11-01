using System;

namespace IntroToDotNet.Syntax
{
	public static class ConsoleHelper
	{
		public static void WriteHeading(string heading)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Write("------------------------------");
			Write(heading);
			Write("------------------------------\n");
			Console.ForegroundColor = ConsoleColor.Black;
			Pause();
		}

		public static void WriteSubHeading(string text, bool isFirst = false)
		{
			var preFormatter = isFirst ? string.Empty : "\n";
			Write($"{preFormatter}{text}");
		}

		public static void Write(string text)
		{
			Console.WriteLine(text);
		}

		public static void AskIfThereAreQuestions()
		{
			WriteAndPause("Any questions?");
		}

		public static void WriteAndPause(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Write("\n");
			Write(text);
			Console.ForegroundColor = ConsoleColor.Black;
			Pause();
		}

		public static void WriteSnippet(string text, bool addExampleText = true)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;

			if (addExampleText)
			{
				var whitespace = "";
				if (text.Length > 8)
				{
					for (int i = 0; i < text.Length - 8; i++)
					{
						whitespace += " ";
					}
				}

				Write($"\nExample:{whitespace}");
			}

			Write(text);
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.ForegroundColor = ConsoleColor.Black;
		}

		public static void Pause()
		{
			Console.ReadLine();
		}
	}
}