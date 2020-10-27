using System;

namespace IntroToDotNet.Syntax.vNext
{
	public static class Numbers
	{
		private static void SyntaxOnly()
		{
			// Shorts are less commonly used since their max range is very small
			short sixteenBitNumber = 10;

			// These are the min and max values for a short
			sixteenBitNumber = short.MinValue;
			sixteenBitNumber = short.MaxValue;

			// Integers are most commonly used whole numbers
			int thirtyTwoBitNumber = 11;

			// These are the min and max values for an int
			thirtyTwoBitNumber = int.MinValue;
			thirtyTwoBitNumber = int.MaxValue;

			// If you need something larger, you can use a long
			long sixtyFourBitNumber = 12;

			// These are the min and max values for a long
			sixtyFourBitNumber = long.MinValue;
			sixtyFourBitNumber = long.MaxValue;

			// A float is a 32bit number with ~6-9 digit precision and are most commonly used for fast processing like graphics. Notice the 'f'.
			float floatingNumber = 13.00f;

			// These are the min and max values for a float
			floatingNumber = float.MinValue;
			floatingNumber = float.MaxValue;

			// A double is a 64bit number with a ~15-17 digit precision and is most commonly used when fractions are needed
			double doubleNumber = 14.000;

			// These are the min and max values for a double
			doubleNumber = double.MinValue;
			doubleNumber = double.MaxValue;

			// A decimal is a 128bit number with a 28-29 digit precision and is used mainly for financial applications. Notice the 'M'
			decimal decimalNumber = 15.0000M;

			// These are the min and max values for a decimal
			decimalNumber = decimal.MinValue;
			decimalNumber = decimal.MaxValue;

			// All of these types default to zero
			_ = default(short);
			_ = default(int);
			_ = default(long);
			_ = default(float);
			_ = default(double);
			_ = default(decimal);

			// In general, each numeric value can be implicitly converted upwards to it's higher counterpart (i.e., short to int or int to long)
			thirtyTwoBitNumber = sixteenBitNumber;
			sixtyFourBitNumber = thirtyTwoBitNumber;
			floatingNumber = sixtyFourBitNumber;
			doubleNumber = floatingNumber;

			// Double to decimal is the only conversion you cannot do this because a double is much larger, but this is how you would:
			decimalNumber = Convert.ToDecimal(doubleNumber);

			// When adding multiple types together, the result is the largest of the types
			float floatResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber;
			double doubleResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber + doubleNumber;

			// Decimals are a different breed, but you can still do it like we did earlier
			decimal decimalResult = Convert.ToDecimal(doubleResult) + Convert.ToDecimal(floatResult);
		}

		public static void Demo()
		{
			ConsoleHelper.WriteHeading("These are the various numeric types you can use.");

			ConsoleHelper.WriteSubHeading("Shorts are less commonly used since their max range is very small", true);
			ConsoleHelper.WriteSnippet("short sixteenBitNumber = 10;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for a short");
			ConsoleHelper.WriteSnippet($"sixteenBitNumber = short.MinValue; = {short.MinValue}");
			ConsoleHelper.WriteSnippet($"sixteenBitNumber = short.MaxValue; = {short.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Integers are most commonly used whole numbers");
			ConsoleHelper.WriteSnippet("int thirtyTwoBitNumber = 11;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for an int");
			ConsoleHelper.WriteSnippet($"thirtyTwoBitNumber = int.MinValue; = {int.MinValue}");
			ConsoleHelper.WriteSnippet($"thirtyTwoBitNumber = int.MaxValue; = {int.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("If you need something larger, you can use a long");
			ConsoleHelper.WriteSnippet("long sixtyFourBitNumber = 12;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for a long");
			ConsoleHelper.WriteSnippet($"sixtyFourBitNumber = long.MinValue; = {long.MinValue}");
			ConsoleHelper.WriteSnippet($"sixtyFourBitNumber = long.MaxValue; = {long.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("A float is a 32bit number with ~6-9 digit precision and are most commonly used for fast processing like graphics. Notice the 'f'.");
			ConsoleHelper.WriteSnippet("float floatingNumber = 13.00f;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for a float");
			ConsoleHelper.WriteSnippet($"floatingNumber = float.MinValue; = {float.MinValue}");
			ConsoleHelper.WriteSnippet($"floatingNumber = float.MaxValue; = {float.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("A double is a 64bit number with a ~15-17 digit precision and is most commonly used when fractions are needed");
			ConsoleHelper.WriteSnippet("double doubleNumber = 14.000;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for a double");
			ConsoleHelper.WriteSnippet($"doubleNumber = double.MinValue; = {double.MinValue}");
			ConsoleHelper.WriteSnippet($"doubleNumber = double.MaxValue; = {double.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("A decimal is a 128bit number with a 28-29 digit precision and is used mainly for financial applications. Notice the 'M'");
			ConsoleHelper.WriteSnippet("decimal decimalNumber = 15.0000M;");

			ConsoleHelper.WriteSubHeading("These are the min and max values for a decimal");
			ConsoleHelper.WriteSnippet($"decimalNumber = decimal.MinValue; = {decimal.MinValue}");
			ConsoleHelper.WriteSnippet($"decimalNumber = decimal.MaxValue; = {decimal.MaxValue}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("All of these types default to zero");
			ConsoleHelper.WriteSnippet($"_ = default(short); = {default(short)}");
			ConsoleHelper.WriteSnippet($"_ = default(int); = {default(int)}", false);
			ConsoleHelper.WriteSnippet($"_ = default(long); = {default(long)}", false);
			ConsoleHelper.WriteSnippet($"_ = default(float); = {default(float)}", false);
			ConsoleHelper.WriteSnippet($"_ = default(double); = {default(double)}", false);
			ConsoleHelper.WriteSnippet($"_ = default(decimal); = {default(decimal)}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("In general, each numeric value can be implicitly converted upwards to it's higher counterpart (i.e., short to int or int to long)");
			ConsoleHelper.WriteSnippet("thirtyTwoBitNumber = sixteenBitNumber;");
			ConsoleHelper.WriteSnippet("sixtyFourBitNumber = thirtyTwoBitNumber;", false);
			ConsoleHelper.WriteSnippet("floatingNumber = sixtyFourBitNumber;", false);
			ConsoleHelper.WriteSnippet("doubleNumber = floatingNumber;", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Double to decimal is the only conversion you cannot do this because a double is much larger, but this is how you would:");
			ConsoleHelper.WriteSnippet("decimalNumber = Convert.ToDecimal(doubleNumber);");
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("When adding multiple types together, the result is the largest of the types");
			short sixteenBitNumber = 10;
			int thirtyTwoBitNumber = 11;
			long sixtyFourBitNumber = 12;
			float floatingNumber = 13.00f;
			double doubleNumber = 14.000;
			float floatResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber;
			double doubleResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber + doubleNumber;
			ConsoleHelper.WriteSnippet($"float floatResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber; = {floatResult}");
			ConsoleHelper.WriteSnippet($"double doubleResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber + doubleNumber; = {doubleResult}", false);
			ConsoleHelper.Pause();

			ConsoleHelper.WriteSubHeading("Decimals are a different breed, but you can still do it like we did earlier");
			ConsoleHelper.WriteSnippet($"decimal decimalResult = Convert.ToDecimal(doubleResult) + Convert.ToDecimal(floatResult); = {Convert.ToDecimal(doubleResult) + Convert.ToDecimal(floatResult)}");
			ConsoleHelper.Pause();

			ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}