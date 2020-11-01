namespace IntroToDotNet.Syntax
{
	internal class Teacher : Person
	{
		public int Grade { get; set; }

		public override string ToString()
		{
			return $"{LastName}, {FirstName} - {Grade} grade";
		}
	}
}