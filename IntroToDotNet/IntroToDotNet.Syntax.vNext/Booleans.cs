namespace IntroToDotNet.Syntax.vNext
{
	public static class Booleans
	{
		private static void SyntaxOnly()
		{
			// Default value is false
			bool imFalseByDefault = default;

			bool imTrue = true;
			bool imFalse = false;

			// You can parse words into a boolean value. Parse will throw an exception if the value is incorrect.
			bool.Parse("true");
			bool.Parse("True");
			bool.Parse("TrUe");
			bool.Parse("false");
			bool.Parse("False");
			bool.Parse("FaLse");

			// You cannot parse anything else into a bool so it is usually better to use TryParse insted.
			bool.TryParse("Y", out var val);
		}

		public static void Demo()
		{
			ConsoleHelper.WriteHeading("This is how boolean values are used.");

			ConsoleHelper.WriteSubHeading("Default value is false", true);
			ConsoleHelper.WriteSnippet("bool imFalseByDefault = default;");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("You can parse words into a boolean value. Parse will throw an exception if the value is incorrect.");
			ConsoleHelper.WriteSnippet($"bool.Parse(\"true\"); = {bool.Parse("true")}");
			ConsoleHelper.WriteSnippet($"bool.Parse(\"True\");	= {bool.Parse("True")}", false);
			ConsoleHelper.WriteSnippet($"bool.Parse(\"TrUe\");	= {bool.Parse("TrUe")}", false);
			ConsoleHelper.WriteSnippet($"bool.Parse(\"false\"); = {bool.Parse("false")}", false);
			ConsoleHelper.WriteSnippet($"bool.Parse(\"False\"); = {bool.Parse("False")}", false);
			ConsoleHelper.WriteSnippet($"bool.Parse(\"FaLse\"); = {bool.Parse("FaLse")}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("You cannot parse anything else into a bool so it is usually better to use TryParse insted.");
			var isSuccess = bool.TryParse("Y", out var val);
			ConsoleHelper.WriteSnippet($"bool.TryParse(\"Y\", out var val); = Was Parsed: {isSuccess}; Parsed Value: {val}");
			ConsoleHelper.Pause();

			ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}