namespace IntroToDotNet.Syntax.vNext
{
	class Strings
	{
		private static void SyntaxOnly()
		{
			// We declare strings like this:
			var imAString = "string";

			// Notice the keyword 'var'. This is short for variable and can represents any type. We can also do this:
			var imAString2 = "string";
			ConsoleHelper.WriteSnippet("string thisIsAString = \"string\";");
			ConsoleHelper.Pause();

			// Default value of a string is null. Default is an operator or literal you can use to get or determine if a value is it's default value:
			string thisIsAString = default;

			// We can set the string to empty:
			thisIsAString = string.Empty;

			// Or we can give it a value:
			thisIsAString = "I have a value now!";

			// You can use functions off an empty string:
			var emptyString = string.Empty;
			int strLength = emptyString.Length;

			// Null strings will cause a NullReferenceException when functions are called:
			string nullString = null;
			//nullString.Length;

			// The most common way to check whether a string is usable is to do this:
			bool isNullOrWhitespace = string.IsNullOrWhiteSpace(thisIsAString);

			//There are many different ways to do string concatenation:
			// 1) Adding strings together:
			string concatenated = "String concatenation with a + " + " is old school.";

			// 2) String format function:
			var concatValue = "concat me!";
			concatenated = string.Format("String concatenation using string.format {0}", concatValue);

			// 3) String interpolation
			concatenated = $"String concatenation using string interpolation {concatValue}";

			// We can transform strings easily:
			string formatValue = "Transfrom Me";
			var upper = formatValue.ToUpper();
			var lower = formatValue.ToLower();

			formatValue = $"  {formatValue}  ";
			var trimStart = formatValue.TrimStart();
			var trimEnd = formatValue.TrimEnd();
			var trim = formatValue.Trim();

			formatValue = "Achiever";
			formatValue = formatValue.Substring(2, 2);

			// This is what a string literal looks like:
			string verbatimStringLiteral = @"This
                                             Is 
                                             A
                                             Literal
                                             c:\hello.txt"; // back slashes are usually used to as an escape key

			// You can create a char using single ticks:
			char character = 'a';
		}

		public static void Demo()
		{
			ConsoleHelper.WriteHeading("First let's checkout strings:");

			ConsoleHelper.WriteSubHeading("We declare strings like this:", true);
			ConsoleHelper.WriteSnippet("var thisIsAString = \"string\";");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Notice the keyword 'var'. This is short for variable and can represents any type. We can also do this:");
			ConsoleHelper.WriteSnippet("string thisIsAString = \"string\";");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Default value of a string is null. Default is an operator or literal you can use to get or determine if a value is it's default value:");
			ConsoleHelper.WriteSnippet("string thisIsAString = default; = null");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("We can set the string to empty:");
			ConsoleHelper.WriteSnippet("thisIsAString = string.Empty;");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Or we can give it a value:");
			ConsoleHelper.WriteSnippet("thisIsAString = \"I have a value now!\";");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading($"You can use functions off an empty string.");
			ConsoleHelper.WriteSnippet("var emptyString = string.Empty;");
			ConsoleHelper.WriteSnippet($"emptyString.Length; = {string.Empty.Length}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Null strings will cause a NullReferenceException when functions are called:");
			ConsoleHelper.WriteSnippet("string nullString = null;");
			ConsoleHelper.WriteSnippet("nullString.Length", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("The most common way to check whether a string is usable is to do this:");
			ConsoleHelper.WriteSnippet("string.IsNullOrWhiteSpace(thisIsAString)");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("There are many different ways to do string concatenation:");
			ConsoleHelper.Write("1) Adding strings together:");
			ConsoleHelper.WriteSnippet("\"String concatenation with a + \"" + "\" is old school.\"");
			ConsoleHelper.Pause();
			ConsoleHelper.Write("2) String format function:");
			ConsoleHelper.WriteSnippet("string.Format(\"String concatenation using string.format {0}\", concatValue)");
			ConsoleHelper.Pause();
			ConsoleHelper.Write("3) String interpolation");
			ConsoleHelper.WriteSnippet("$\"String concatenation using string interpolation {concatValue}\"");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("We can transform strings easily:");
			string formatValue = "Transform Me";
			ConsoleHelper.WriteSnippet("string formatValue = \"Format Me\";");
			ConsoleHelper.WriteSnippet($"formatValue.ToUpper(); = {formatValue.ToUpper()}", false);
			ConsoleHelper.WriteSnippet($"formatValue.ToLower(); = {formatValue.ToLower()}", false);
			formatValue = $"  {formatValue}  ";
			ConsoleHelper.WriteSnippet("formatValue = $\"  {formatValue}  \";", false);
			ConsoleHelper.WriteSnippet($"formatValue.TrimStart(); = {formatValue.TrimStart()}", false);
			ConsoleHelper.WriteSnippet($"formatValue.TrimEnd(); = {formatValue.TrimEnd()}", false);
			ConsoleHelper.WriteSnippet($"formatValue.Trim(); = {formatValue.Trim()}", false);
			formatValue = "Achiever";
			ConsoleHelper.WriteSnippet("formatValue = \"Achiever\";", false);
			ConsoleHelper.WriteSnippet($"formatValue.Substring(2, 2); = {formatValue.Substring(2, 2)}", false);
			ConsoleHelper.Pause();

			string verbatimStringLiteral = @"This
                                             Is 
                                             A
                                             Literal
                                             c:\hello.txt"; // back slashes are usually used to as an escape key
			ConsoleHelper.WriteSubHeading($"This is what a string literal looks like:");
			ConsoleHelper.WriteSnippet(@"This
	                             Is 
	                             A
	                             Literal
	                             c:\hello.txt // back slashes are usually used to as an escape key");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("You can create a char using single ticks:");
			ConsoleHelper.WriteSnippet("char character = 'a';");
			ConsoleHelper.Pause();

			ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}