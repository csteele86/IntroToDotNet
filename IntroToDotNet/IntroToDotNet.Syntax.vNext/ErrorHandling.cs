using System;

namespace IntroToDotNet.Syntax.vNext
{
	public static class ErrorHandling
	{
		private static void SyntaxOnly()
		{
			// TODO: tidy up

			// Error handling is something you should not use often because it is usually 
			// best practices to allow errors to bubble up to a centralized location for 
			// logging and handling. However, this is how it is done!

			try
			{
				try
				{
					try
					{
						try
						{
							// The code you believe may throw an exception would go here
							throw new NotImplementedException("I'm not implemented yet man!");
						}
						catch (NotImplementedException)
							// We can catch any type of exception that inherits the base class Exception
						{
							// Throw simply continues the exception that it caught upwards through your application
							throw;
						}
						catch (Exception ex)
						{
							throw;
						}
						finally
						{
							// If there is code that always needs to execute, regardless if an exception occurs, it goes here
							ConsoleHelper.Write("An exception occurred but I still ran in the finally block");
						}

					}
					catch (Exception ex)
					{
						ConsoleHelper.Write($"An exception was caught:\n{ex}");

						// This will remove the inner exceptions of the exception and is usually not a good idea to do
						// because you usually want as much information about an exception as you can
						throw new ArgumentException("The argument is wrong yo!");
					}
				}
				catch (Exception ex)
				{
					// The exception detail will be different now, masking the true issue
					ConsoleHelper.Write($"An exception was caught:\n{ex}");
					throw;
				}
			}
			catch (Exception ex)
			{
				// Since the exception was re-thrown, we will get the proper exception details
				ConsoleHelper.Write($"An exception was caught:\n{ex}");
			}
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("Last but not least, let's explore error handling!");

			//TODO: add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}