using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroToDotNet.Syntax
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.Title = "C# Syntax Demo";

            WriteHeading("Welcome to the C# Syntax Demo!");

            DemoStrings();
            DemoValueTypes();
            DemoDateTimes();
            DemoConditionsSwitchesAndOperators();
            DemoArrays();
            DemoCollections();
            DemoLoops();
            DemoLinq();
            DemoErrorHandling();

            WriteAndPause("Well that is everything in a nutshell. Any final questions??");
        }

        private static void DemoStrings()
        {
            WriteHeading("First let's checkout strings:");

            // New string with a default value of null
            string thisIsAString = default(string);

            // We can set the string to empty
            thisIsAString = string.Empty;

            // Or we can give it a value
            thisIsAString = "I have a value now!";

            // Notice the keyword 'var'. This is short for variable and can represents any type
            var emptyString = string.Empty;
            Console.WriteLine($"You can use functions off an empty string. Length = {emptyString.Length}");

            string nullString = null;
            // Null strings will cause an exception when functions are called
            //Console.WriteLine(nullString.Length);

            // The best way to check whether a string is usable is to do this
            Console.WriteLine($"Is this string usable? {string.IsNullOrWhiteSpace(thisIsAString)}");
            // Less commonly used is string.IsNullOrEmpty

            // There are many different ways to do string concatenation
            Console.WriteLine("String concatenation with a + " + "is usually not an ideal approach.");
            string concatValue = "is a better approach";
            Console.WriteLine(string.Format("String concatenation using string.format {0}", concatValue));
            concatValue = "is the recommended approach";
            Console.WriteLine($"String concatenation using string interpolation {concatValue}");

            // We can format strings easily
            string formatValue = "Format Me";
            Console.WriteLine($"This string is all uppercase now {formatValue.ToUpper()}");
            Console.WriteLine($"This string is all lowercase now {formatValue.ToLower()}");

            formatValue = $"  {formatValue}  ";
            Console.WriteLine($"This strings value has changed from '{formatValue}' to {formatValue.TrimStart()} by trimming the beginning");
            Console.WriteLine($"This strings value has changed from '{formatValue}' to {formatValue.TrimEnd()} by trimming the end");
            Console.WriteLine($"This strings value has changed from '{formatValue}' to {formatValue.Trim()} by trimming both ends");

            formatValue = "Achiever";
            Console.WriteLine($"We can substring {formatValue} to get {formatValue.Substring(2,2)}");

            string verbatimStringLiteral = @"This
                                             Is 
                                             A
                                             Literal
                                             c:\hello.txt"; // back slashes are usually used to as an escape key
            Console.WriteLine($"This is what a string literal looks like: {verbatimStringLiteral}");

            // You can create a char using single ticks
            char character = 'a';

            AskIfThereAreQuestions();
        }

        #region Value Types
        private static void DemoValueTypes()
        {
            WriteHeading("There are many different value types that can be used. Let's explore them.");

            DemoValueTypeNumerics();
            DemoValueTypeBool();
            DemoValueTypeEnum();

            WriteAndPause("Any final questions about value types?");
        }

        private static void DemoValueTypeNumerics()
        {
            WriteHeading("These are the various numeric types you can use.");

            short sixteenBitNumber = 10;

            // Integers are most commonly used
            int thirtyTwoBitNumber = 11;

            long sixtyFourBitNumber = 12;

            // 32bit 7 digit precision
            // Most commonly used for fast processing like graphics
            // We have to use the formatter 'f' to set the value for a float
            float floatingNumber = 13.00f;

            // 64bit 15-16 digit precision
            // Most commonly used when fractions are needed
            double doubleNumber = 14.000;

            // 128bit 28-29 digit precision
            // Used mainly for financial applications
            // We have to use the formatter 'M' to set the value for a decimal
            decimal decimalNumber = 15.0000M;

            short maxSixteenBitNumber = short.MaxValue;
            int maxThirtyTwoBitNumber = int.MaxValue;
            long maxSixtyFourBitNumber = long.MaxValue;
            float maxFloatingNumber = float.MaxValue;
            double maxDoubleNumber = double.MaxValue;
            decimal maxDecimalNumber = decimal.MaxValue;

            Console.WriteLine($"All numerical values have constants for their max values \nshort {maxSixteenBitNumber} \nint {maxThirtyTwoBitNumber}\nlong {maxSixtyFourBitNumber}\nfloat {maxFloatingNumber}\ndouble {maxDoubleNumber}\ndecimal {maxDecimalNumber}");

            // In general, each numeric value can be implicitly converted upwards to 
            // it's higher counterpart (i.e., short to int or int to long)
            thirtyTwoBitNumber = sixteenBitNumber;
            sixtyFourBitNumber = thirtyTwoBitNumber;
            floatingNumber = sixtyFourBitNumber;
            doubleNumber = floatingNumber;

            // This cannot be done, but we can still achieve it with Convert
            //decimalNumber = doubleNumber;
            decimalNumber = Convert.ToDecimal(doubleNumber);

            // The result type becomes the largest of the types added together
            float floatResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber;
            double doubleResult = sixteenBitNumber + thirtyTwoBitNumber + sixtyFourBitNumber + floatingNumber + doubleNumber;
            
            // Decimals are a different breed, but you can still convert a number to decimal
            decimal decimalResult = Convert.ToDecimal(doubleResult) + Convert.ToDecimal(floatResult);

            AskIfThereAreQuestions();
        }

        private static void DemoValueTypeBool()
        {
            WriteHeading("This is how boolean values are used.");

            // Default value is false
            bool imFalseByDefault;

            bool imTrue = true;
            bool imFalse = false;

            Console.WriteLine($"You can parse the word 'true' into a bool:  {bool.Parse("true")}");
            Console.WriteLine($"You can parse the word 'True' into a bool:  {bool.Parse("True")}");
            Console.WriteLine($"You can parse the word 'false' into a bool:  {bool.Parse("false")}");
            Console.WriteLine($"You can parse the word 'False' into a bool:  {bool.Parse("False")}");

            AskIfThereAreQuestions();
        }

        private static void DemoValueTypeEnum()
        {
            WriteHeading("This is how enum values are used.");

            // Default value is the first item in the enum
            BodyStyle bodyStyle = default(BodyStyle);
            Console.WriteLine($"This is the default value {bodyStyle}");

            Console.WriteLine($"You can cast an enum to it's string representation '{BodyStyle.Van}' or the numerical representation '{(int)BodyStyle.Van}'");

            // You can set the value of an enum using a number as well
            BodyStyle unknownBodyStyle = (BodyStyle) 100;
            Console.WriteLine($"Unknown body style is '{unknownBodyStyle}'");

            // So it is usually best to check if the enum is defined when passed a parameter to a public or protected method
            Console.WriteLine($"Is enum defined: {Enum.IsDefined(typeof(BodyStyle), unknownBodyStyle)}");

            AskIfThereAreQuestions();
        }
        #endregion

        private static void DemoDateTimes()
        {
            WriteHeading("Now lets explore how dates can be used.");

            DateTime defaultDate = default(DateTime);
            Console.WriteLine($"This is the default value for date time: {defaultDate}");
            
            // We can get the current time in multiple formats
            var currentTime = DateTime.Now;
            Console.WriteLine($"The current local time is {currentTime}");

            var currentUtcTime = DateTime.UtcNow;
            Console.WriteLine($"The current UTC time is {currentUtcTime}");

            // We can create our own date as well
            var myBirthdate = new DateTime(1986, 11, 10, 7, 30, 0);
            Console.WriteLine($"I was born on this day and time {myBirthdate}");

            // If we only need the date and no time, we use Today
            var today = DateTime.Today;
            Console.WriteLine($"Today is {today}");

            // Wait, there was still a time when that printed out! Let's remove that...
            Console.WriteLine($"This is truly today only {today.ToShortDateString()}");

            // We can also get various pieces of a date.
            Console.WriteLine($"Year: {currentTime.Year}");
            Console.WriteLine($"Month: {currentTime.Month}");
            Console.WriteLine($"Day: {currentTime.Day}");
            Console.WriteLine($"Day of Week: {currentTime.DayOfWeek}");
            Console.WriteLine($"Hour: {currentTime.Hour}");
            Console.WriteLine($"Minute: {currentTime.Minute}");
            Console.WriteLine($"Second: {currentTime.Second}");
            Console.WriteLine($"Millisecond: {currentTime.Millisecond}");
            Console.WriteLine($"Ticks: {currentTime.Ticks}");

            // We can also format a date to our liking
            Console.WriteLine($"Our formatted date is {currentTime.ToString("yyyy MMMM dd hh:mm:ss tt zzz")}");

            // We can add or subtract dates too. This gives us a TimeSpan aka a span of time or duration
            TimeSpan diffBetweenMyBdayAndNow = currentTime - myBirthdate;
            Console.WriteLine($"My birthday was '{diffBetweenMyBdayAndNow.TotalDays}' days ago or '{diffBetweenMyBdayAndNow.TotalHours}' hours ago :(");

            AskIfThereAreQuestions();
        }

        private static void DemoConditionsSwitchesAndOperators()
        {
            WriteHeading("You can't have a program without conditions. What do they look like?");

            Console.WriteLine(@"These are the various comparison operators:
==  equal
!=  not equal
>   greater than
<   less than
>=  greater than or equal
<=  less than or equal");

            Random random = new Random();

            int num = random.Next(100);
            if (num < 50)
            {
                Console.WriteLine($"Number is less than 50: {num}");
            }
            else if (num >= 50)
            {
                Console.WriteLine($"Number is greater than or equal to 50: {num}");
            }

            int num2 = random.Next(100);
            if (num2 % 2 == 0)
            {
                Console.WriteLine($"Number is an equal number: {num2}");
            }
            else 
            {
                Console.WriteLine($"Number must not be an equal number: {num2}");
            }

            Console.WriteLine(@"These are the various conditional operators:
&&  logical AND
||  logical OR
!   logical NOT (often read as 'bang')
^   logical XOR (exclusive OR) See https://msdn.microsoft.com/en-us/library/zkacc7k1.aspx for more info on XOR");

            int num3 = random.Next(100);
            if (num3 >= 0 && num3 <= 20)
            {
                Console.WriteLine($"Number is between 0 and 20");
            } 
            else if ((num3 > 20 && num3 <= 30) || (num3 >= 70 && num3 <= 80) && !(num3 >= 90))
            {
                Console.WriteLine($"Number is either between 21-30 or 70-80 and not greater than 90: {num3}");
            }
            else
            {
                Console.WriteLine($"Number failed all conditions: {num3}");
            }

            Console.WriteLine("Switch statements are just like if/else, but are preferred when there might be a lot of conditions");

            int num4 = random.Next(100);
            switch (num4)
            {
                case 1:
                    Console.WriteLine("We sure got lucky that the number was 1");
                    break;
                case 40:
                    Console.WriteLine("We sure got lucky that the number was 40");
                    break;
                case 55:
                case 67:
                    Console.WriteLine($"We sure got lucky that the number was 55 or 67 - {num4}");
                    break;
                default:
                    Console.WriteLine($"Darn! We didn't get lucky. The number is {num4}");
                    break;
            }

            AskIfThereAreQuestions();
        }

        private static void DemoArrays()
        {
            WriteHeading("Arrays are fun! This is how they are used:");

            // An array can be created many different ways:
            // By defining an upper bound (long way). This can hold 3 values starting with the 0 index
            string[] longHandArray = new string[5] { "hello", "my", "name", "is", "Chris" };

            // Without defining an upper bound (shorter way). The upper bound is derived
            string[] shortHandArray = new string[] {"hello", "my", "name", "is", "Chris"};

            // Without defining a type on the right side of the equal sign (shortest way).
            string[] shortestHandArray1 = {"hello", "my", "name", "is", "Chris"};
            // Or use var
            var shortestHandArray2 = new[] {"hello", "my", "name", "is", "Chris"};

            // Less commonly used are multi-dimensional arrays
            // Creates a 2 x 3 array 
            int[,] multiDimensionArray1 = new int[2,3] { {1, 2, 3}, {1, 2, 3} };
            var multiDimensionArray2 = new [,] { {1, 2, 3}, {1, 2, 3} };

            // Even less commonly used are jagged arrays
            int[][] jaggedArray1 = new int[2][];
            jaggedArray1[0] = new[] {1, 2};

            // And if I didn't have a good reason to use multi-dimension or jagged arrays, 
            // we can finally create a multi-dimension jagged array
            int[,][] jaggedMultiDimensionArray = new int[2,2][];
            jaggedMultiDimensionArray[0,0] = new int[] {1, 2};

            // Back to reality!
            // We can get arrays by splitting a string too
            var commaDilemented = "1, 2, 3, 4, 5, 6,";
            var splitArray = commaDilemented.Split(',');
            
            // We can also write out/flatten an array quick and easy using string.join
            Console.WriteLine($"The array values are '{string.Join("|", splitArray)}'");

            // Wait, what was with the spacing? Let's split the string again differently
            splitArray = commaDilemented.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"The array values are '{string.Join("|", splitArray)}'");

            // You can also retrieve values in an array from an index
            var index0Value = splitArray[0];

            // Or set them for that matter
            Console.WriteLine($"Index 0 value is '{splitArray[0]}'");
            splitArray[0] = "It's Changed!";
            Console.WriteLine($"Now index 0 value is '{splitArray[0]}'");

            // This is how to check if an array contains values or not
            if (splitArray != null && splitArray.Length > 0)
            {
                Console.WriteLine($"The array has {splitArray.Length} values!");
            }

            AskIfThereAreQuestions();
        }

        private static void DemoCollections()
        {
            WriteHeading("Collections are commonly used and are super useful. This is how they are used:");
            
            // Lists allow you to store a collection of any type you need to use

            // Like an array, you can create a list many different ways:
            // You can create empty lists
            List<int> myList = new List<int>();

            // Or you can populate it when you instantiate it
            myList = new List<int>() { 2, 3, 4 };

            // Or you can use an array to initialize a list as well
            string[] numbers = "1, 2, 3, 4, 5, 6,".Split(',');
            List<string> myNumbers = new List<string>(numbers);

            // This is how you add more values to a list. It must be of the same type
            myList.Add(2);  
            // This does not work
            //myList.Add("2");

            // You can remove an item based on an item in the list
            myNumbers.Remove("1");

            // You can also insert new items in a specific index
            myNumbers.Insert(0, "100"); 

            // This is how you would remove at a specified index
            myNumbers.RemoveAt(0);

            // This removes anything that contains '2'. The LINQ demo will describe this syntax later
            myNumbers.RemoveAll(c => c.Contains("2"));

            // You can retrieve a value based on an index too
            Console.WriteLine($"The list value at index 0 is '{myNumbers[0]}'.");
            
            // This is how to see how many values are in the list
            Console.WriteLine($"The list has '{myNumbers.Count}' values.");

            // This is how you determine if a list has values 
            if (myNumbers != null && myNumbers.Any())
            {
                Console.WriteLine("The list has values!");
            }

            // This is how to clear a list 
            myNumbers.Clear(); 

            // Like the array, we can easily display the values of a list
            Console.WriteLine($"The list contains the following values: {string.Join("|", myList)}");

            // You can also make changes to each item in the list by doing this. The LINQ demo will describe this syntax later
            myList.ForEach(item => Console.WriteLine(item));

            AskIfThereAreQuestions();
        }

        private static string[] GetDemoArray()
        {
            return new[] {"Hello", "World!", "Are", "We", "Having", "Fun", "Yet?"};
        }

        private static void DemoLoops()
        {
            WriteHeading("Let's explore the world of loops!");

            // Most commonly used is the for each using an array
            string[] array = GetDemoArray();
            foreach (string val in array)
            {
                Console.WriteLine($"For each loop array value is {val}");
            }

            List<string> list = array.ToList(); // Oh, btw, you can cast an array to a list :)
            // It works the same way for lists too
            foreach (string val in list)
            {
                Console.WriteLine($"For each loop list value is {val}");
            }

            // Next is a generic for loop using Length for the upper bound
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"For loop array value is {array[i]}");
            }

            // Again, the same works for lists, but we use Count as the upper bounds
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"For loop list value is {list[i]}");
            }

            // Then there is a while loop. These are not used often, but when you do, 
            // be careful you don't make it an endless loop :)
            int index = 0;
            while (index < list.Count)
            {
                Console.WriteLine($"While loop list value is {list[index]}");
                index++; 
            }

            // Then finally there is the do while loop. Much the same as the while loop 
            // but the condition is at the end
            index = 0;
            do
            {
                Console.WriteLine($"Do while loop list value is {list[index]}");
                index++;
            } while (index < list.Count);

            AskIfThereAreQuestions();
        }

        private static List<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
                new Teacher { FirstName = "Jane", LastName = "Doe", Grade =  3},
                new Teacher { FirstName = "John", LastName = "Snow", Grade =  12},
                new Teacher { FirstName = "Marvin", LastName = "Wolf", Grade =  6},
                new Teacher { FirstName = "Luke", LastName = "Carter", Grade =  5},
                new Teacher { FirstName = "Bernice", LastName = "Fox", Grade =  9},
                new Teacher { FirstName = "Christopher", LastName = "Steele", Grade =  13} // huh??
            };
        }

        private static void DemoLinq()
        {
            WriteHeading("LINQ?! What is that?? Let's explore.");

            // LINQ stands for Language-Integrated Query essentially is a way to 
            // query collections using extension methods. Extension methods are 
            // a lot like they sound. They extend a type to provide additional 
            // functionality. LINQ will be your friend someday as it cuts down
            // on a lot of coding!

            List<Teacher> teachers = GetTeachers();

            // Say I want teachers who teach 9th grade and up. We can just do this.
            // The "=>" syntax is called a lambda expression; essentially it's shorthand for creating functions
            IEnumerable<Teacher> ninthGradeAndUp = teachers.Where(teacher => teacher.Grade >= 9);

            // Now let's make what we retrieved legible. We can use the Select method to retrieve a subset of the collection
            IEnumerable<string> legibleNinthGradeTeachers =
                ninthGradeAndUp.Select(teacher => $"{teacher.LastName}, {teacher.FirstName} - {teacher.Grade} grade");

            Console.WriteLine($"These are the teachers 9th grade and up:\n{string.Join("\n", legibleNinthGradeTeachers)}");

            // We also have the ability to skip or take a specific amount.
            IEnumerable<Teacher> skipAndTakeTeachers = teachers.Skip(2).Take(3);

            // Please note that since we overrode the ToString method on the Teacher class, .NET will use the ToString 
            // method to get our custom value; otherwise it would use the fully qualified name - IntroToDotNet.Syntax.Teacher
            Console.WriteLine($"These are the teachers we chose after skipping 2 and taking 3:\n{string.Join("\n", skipAndTakeTeachers)}");

            // Let's say we want to find a specific record in a collection. We would do this
            // This will return the default value of what you are looking for if not found
            Teacher specificTeacher = teachers.Where(teacher => teacher.Grade == 13).FirstOrDefault();
            // Or like this
            specificTeacher = teachers.FirstOrDefault(teacher => teacher.Grade == 13);
            // Or like this, but it will throw an exception if nothing is found
            specificTeacher = teachers.Where(teacher => teacher.Grade == 13).First();
            // Or like this
            specificTeacher = teachers.First(teacher => teacher.Grade == 13);

            Console.WriteLine($"Specific teacher is {specificTeacher}");

            // We can use the DefaultIfEmpty which will use whatever you pass in the parameter if the
            // code encounters no values. 
            IEnumerable<Teacher> defaultIfEmpty = teachers.Where(teacher => teacher.Grade == 15)
                .DefaultIfEmpty(new Teacher());

            Console.WriteLine($"No teachers were found who teaches 15th grade: {string.Join("\n", defaultIfEmpty)}");
            
            // Maybe you just need to know if values exist in the collection. You can do this
            bool valuesExist = teachers.Any();
                
            // You can do that with a condition as well.
            bool teachersExist = teachers.Any(teacher => teacher.Grade > 13);
            int teacherCount = teachers.Count(teacher => teacher.Grade > 13);
            Console.WriteLine($"Are there any teachers teaching anything above 13th grade? {teachersExist}");

            // Another thing that is handy sometimes is easy casting.
            Teacher[] teachers2 = teachers.ToArray();
            List<Teacher> teachers3 = teachers2.ToList();

            AskIfThereAreQuestions();
        }

        private static void DemoErrorHandling()
        {
            WriteHeading("Last but not least, let's explore error handling!");

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
                            Console.WriteLine("An exception occurred but I still ran in the finally block");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An exception was caught:\n{ex}");

                        // This will remove the inner exceptions of the exception and is usually not a good idea to do
                        // because you usually want as much information about an exception as you can
                        throw new ArgumentException("The argument is wrong yo!");
                    }
                }
                catch (Exception ex)
                {
                    // The exception detail will be different now, masking the true issue
                    Console.WriteLine($"An exception was caught:\n{ex}");
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Since the exception was re-thrown, we will get the proper exception details
                Console.WriteLine($"An exception was caught:\n{ex}");
            }

            AskIfThereAreQuestions();
        }

        private static void WriteHeading(string heading)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------------------------------");
            Console.WriteLine(heading);
            Console.WriteLine("------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }

        private static void AskIfThereAreQuestions()
        {
            WriteAndPause("Any questions?");
        }

        private static void WriteAndPause(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
    }
}
