using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fclp;
using Newtonsoft.Json;

namespace IntroToDotNet.RockPaperScissors
{
	partial class Program
	{
		private const string _bulletPoint = "\u2022";

		enum Move
		{
			Invalid = 0,
			Rock,
			Paper,
			Scissors
		}

		private static readonly Dictionary<Move, Move> _whatBeatsWhat = new Dictionary<Move, Move>
		{
			{Move.Rock, Move.Scissors},
			{Move.Scissors, Move.Paper},
			{Move.Paper, Move.Rock}
		};

		private struct Stats
		{
			public string PlayerName { get; set; }
			public string ComputerName { get; set; }

			public int ComputerWins { get; set; }
			public int HumanWins { get; set; }
			public int Draws { get; set; }

			public bool HasPlayedMoreThanOnce => ComputerWins + HumanWins + Draws > 1;
		}

		private class Args
		{
			public string PlayerName { get; set; }
			public Move Move { get; set; }
		}

		private static Stats _stats;
		private static Args _args;

		static async Task Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			_args = ReadArguments(args) ?? new Args();

			Console.WriteLine("Would you like to play a game?? How about Rock, Paper, Scissors?!");

			_stats.PlayerName = _args.PlayerName;

			if (string.IsNullOrWhiteSpace(_stats.PlayerName))
			{
				Console.WriteLine("\nWhat is your name, player?");
				_stats.PlayerName = Console.ReadLine();
			}

			Console.WriteLine($"\nWelcome {_stats.PlayerName}!");

			_stats.ComputerName = await GetComputerName();
			Console.WriteLine($"\n{_stats.ComputerName} has challenged you!");

			Console.WriteLine("\nGood luck to both of you!");

			Play();
		}

		private static Args ReadArguments(string[] args)
		{
			if (args != null && args.Length > 0)
			{
				Console.WriteLine("\nArguments found! Parsing them,");

				var argParser = new FluentCommandLineParser<Args>();
				argParser.Setup(arg => arg.PlayerName)
					.As('n', "fame")
					.WithDescription("Enter your name.")
					.Required();

				argParser.Setup(arg => arg.Move)
					.As('m', "move")
					.WithDescription("Choose what you want to play - Rock (1), Paper (2), or Scissors (3)")
					.Required();

				var result = argParser.Parse(args);

				if (result.HasErrors)
				{
					Console.WriteLine($"\nErrors found in the arguments passed in:\n{result.ErrorText}");
					Environment.Exit(2);
					return null;
				}

				return argParser.Object;
			}

			Console.WriteLine("\nNo arguments found. Moving on!");
			return null;
		}

		private static async Task<string> GetComputerName()
		{
			using var httpClient = new HttpClient();
			var randomUserApiResponse = await httpClient.GetStringAsync("https://randomuser.me/api/");

			var searalizedRandomUserApiResponse =
				JsonConvert.DeserializeObject<RandomUserApiResponse>(randomUserApiResponse);

			return searalizedRandomUserApiResponse.results[0].name.first + " " +
				   searalizedRandomUserApiResponse.results[0].name.last;
		}

		private static void Play()
		{
			var playerChoice = GetPlayerChoice();
			var computerChoice = GetComputerChoice();

			WhoWon(playerChoice, computerChoice);

			var playAgain = PlayAgain();

			if (playAgain)
				Play();
		}

		private static bool PlayAgain()
		{
			Console.WriteLine("\nWould you like to play again? Y or N");
			string playAgain = Console.ReadLine();

			switch (playAgain.ToLower())
			{
				case "y":
					return true;
				case "n":
					return false;
				default:
					Console.WriteLine($"\nInvalid choice provided ${playAgain}. Please choose again!");
					return PlayAgain();
			}
		}

		private static Move GetPlayerChoice()
		{
			Move actualChoice;
			if (_args.Move != Move.Invalid)
			{
				actualChoice = _args.Move;
				_args.Move = Move.Invalid;
			}
			else
			{
				Console.WriteLine("\nWhat do you want to play? Rock (r), Paper (p), or Scissors (s)");
				var playerChoice = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(playerChoice))
				{
					Console.WriteLine("\nNo choice was provided. Please choose again!");
					return GetPlayerChoice();
				}

				switch (playerChoice.ToLower().ToCharArray()[0])
				{
					case 'r':
						actualChoice = Move.Rock;
						break;
					case 'p':
						actualChoice = Move.Paper;
						break;
					case 's':
						actualChoice = Move.Scissors;
						break;
					default:
						Console.WriteLine($"\nInvalid choice provided ({playerChoice}). Please choose again!");
						return GetPlayerChoice();
				}
			}

			Console.WriteLine($"\nYou've chosen {actualChoice}! Good choice!");
			return actualChoice;
		}

		private static Move GetComputerChoice()
		{
			var rnd = new Random();
			var nextValue = rnd.Next(1, 4);

			var computerChoice = (Move)nextValue;

			Console.WriteLine($"\n{_stats.ComputerName} has chosen {computerChoice}.");

			return computerChoice;
		}

		private static void WhoWon(Move playerChoice, Move computerChoice)
		{
			if (playerChoice == computerChoice)
			{
				Console.WriteLine("\nIt was a draw! No one wins!");
				_stats.Draws += 1;
			}
			else
			{
				var playerBeatsWhat = _whatBeatsWhat[playerChoice];

				if (playerBeatsWhat == computerChoice)
				{
					Console.WriteLine("\nCongratulations! You win!");
					++_stats.HumanWins;
				}
				else
				{
					Console.WriteLine($"\nWomp-womp! It pains me to say this, but {_stats.ComputerName} demolished you!");
					++_stats.ComputerWins;
				}
			}

			if (_stats.HasPlayedMoreThanOnce)
				Console.WriteLine($"\nCurrent stats:\n{_bulletPoint} You have won a total of {_stats.HumanWins}\n" +
								  $"{_bulletPoint} {_stats.ComputerName} has won a total of {_stats.ComputerWins}\n" +
								  $"{_bulletPoint} There have been {_stats.Draws} draws");
		}
	}
}
