using System;

namespace IntroToDotNet.Syntax.vNext
{
	public static class Dates
	{
		private static void SyntaxOnly()
		{
			// The default value for date time is the equivalent to DateTime.MinValue
			DateTime defaultDate = default;

			// We can get the current time in multiple formats
			var currentTime = DateTime.Now;
			var currentUtcTime = DateTime.UtcNow;

			// We can create our own date as well
			var myBirthdate = new DateTime(1986, 11, 10, 7, 30, 0);

			// If we only need the date and no time, we use Today
			var today = DateTime.Today;

			// Wait, there was still a time when that printed out! Let's remove that...
			var justToday = today.ToShortDateString();

			// We can also get various pieces of a date.
			var year = currentTime.Year;
			var month = currentTime.Month;
			var day = currentTime.Day;
			var dow = currentTime.DayOfWeek;
			var hour = currentTime.Hour;
			var minute = currentTime.Minute;
			var second = currentTime.Second;
			var millisecond = currentTime.Millisecond;
			var ticks = currentTime.Ticks;

			// We can also format a date to our liking
			var formmattedDate = $"Our formatted date is {currentTime:yyyy MMMM dd hh:mm:ss tt zzz}";

			// We can add or subtract dates too. This gives us a TimeSpan aka a span of time or duration
			TimeSpan diffBetweenMyBdayAndNow = currentTime - myBirthdate;
			var myBdayWas = $"My birthday was '{diffBetweenMyBdayAndNow.TotalDays}' days ago or '{diffBetweenMyBdayAndNow.TotalHours}' hours ago :(";
		}

		public static void Demo()
		{
			//ConsoleHelper.WriteHeading("Now lets explore how dates can be used.");

			//TODO: add

			//ConsoleHelper.AskIfThereAreQuestions();
		}
	}
}