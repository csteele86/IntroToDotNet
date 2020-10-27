using System;

namespace IntroToDotNet.Syntax.vNext
{
	class Enums
	{
		public enum BodyStyle
		{
			None = 0,
			Sedan = 1,
			Truck = 2,
			Suv = 3,
			Crossover = 4,
			Wagon = 5,
			Van = 6
		}

		private static void SyntaxOnly()
		{
			// Default value is the first item in the enum
			BodyStyle bodyStyle = default;

			bodyStyle = BodyStyle.Van;

			// You can cast an enum to it's string or int representation
			bodyStyle.ToString();
			_ = (int) bodyStyle;

			// You can set the value of an enum using a number as well
			var unknownBodyStyle = (BodyStyle) 1000;

			// Which means it is best to check if the enum is defined
			Enum.IsDefined(typeof(BodyStyle), unknownBodyStyle);

			// And here is how we can parse a string to an enum. Parse will always work with any number, but will fail for invalid names - case sensitivity and just wrong.
			Enum.Parse(typeof(BodyStyle), "Truck");
			Enum.Parse(typeof(BodyStyle), "2");

			// This is how we can safely try to parse with case-insensitivity before using
			Enum.TryParse(typeof(BodyStyle), "CrossOver", true, out var parsedResult);
		}

		public static void Demo()
		{
			ConsoleHelper.WriteHeading("This is how enum values are used.");

			ConsoleHelper.WriteSubHeading("Default value is the first item in the enum:");
			BodyStyle bodyStyle = default;
			ConsoleHelper.WriteSnippet("BodyStyle bodyStyle = default;");
			ConsoleHelper.Pause();

			bodyStyle = BodyStyle.Van;

			ConsoleHelper.WriteSubHeading("You can cast an enum to it's string or int representation:");
			ConsoleHelper.WriteSnippet($"bodyStyle.ToString(); {bodyStyle}");
			ConsoleHelper.WriteSnippet($"(int)bodyStyle; = {(int)bodyStyle}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("You can set the value of an enum using a number as well");
			var unknownBodyStyle = (BodyStyle)1000;
			ConsoleHelper.WriteSnippet("var unknownBodyStyle = (BodyStyle)1000;");

			ConsoleHelper.WriteSubHeading("Which means it is best to check if the enum is defined");
			var isDefined = Enum.IsDefined(typeof(BodyStyle), unknownBodyStyle);;
			ConsoleHelper.WriteSnippet($"var isDefined = Enum.IsDefined(typeof(BodyStyle), unknownBodyStyle); = {isDefined}");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("And here is how we can parse a string to an enum. Parse will always work with any number, but will fail for invalid names - case sensitivity and just wrong.");
			ConsoleHelper.WriteSnippet("var bodyStyle = Enum.Parse(typeof(BodyStyle), \"Truck\");");
			ConsoleHelper.WriteSnippet("var bodyStyle = Enum.Parse(typeof(BodyStyle), \"2\");", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("This is how we can safely try to parse with case-insensitivity before using");
			var didParse = Enum.TryParse(typeof(BodyStyle), "CrossOver", true, out var parsedResult);
			ConsoleHelper.WriteSnippet($"var didParse = Enum.TryParse(typeof(BodyStyle), \"CrossOver\", true, out var parsedResult); = Was Parsed: {didParse}; Parsed Value: {parsedResult}");
			ConsoleHelper.Pause();

			ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}