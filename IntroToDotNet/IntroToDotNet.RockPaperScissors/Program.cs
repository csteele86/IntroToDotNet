using System;
using System.Collections.Generic;

namespace IntroToDotNet.RockPaperScissors
{
	class Program
	{
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

		static void Main(string[] args)
		{
			Console.WriteLine("Would you like to play a game?? How about Rock, Paper, Scissors?!");

			Console.WriteLine("\nWhat is your name, player?");
			var playerName = Console.ReadLine();

			Console.WriteLine($"\nWelcome {playerName}! Good luck to you!");

			var playerChoice = GetPlayerChoice();
			var computerChoice = GetComputerChoice();

			WhoWon(playerChoice, computerChoice);
		}

		private static Move GetPlayerChoice()
		{
			Console.WriteLine("\nWhat do you want to play? Rock (r), Paper (p), or Scissors (s)");
			var playerChoice = Console.ReadLine();

			Move actualChoice;
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

			Console.WriteLine($"\nYou've chosen {actualChoice}! Good choice!");
			return actualChoice;
		}

		private static Move GetComputerChoice()
		{
			var rnd = new Random();
			var nextValue = rnd.Next(1, 3);

			var computerChoice = (Move)nextValue;

			Console.WriteLine($"\nThe computer has chosen {computerChoice}.");

			return computerChoice;
		}

		private static void WhoWon(Move playerChoice, Move computerChoice)
		{
			if (playerChoice == computerChoice)
			{
				Console.WriteLine("\nIt was a draw! No one wins!");
			}
			else
			{
				var playerBeatsWhat = _whatBeatsWhat[playerChoice];

				if (playerBeatsWhat == computerChoice)
				{
					Console.WriteLine("\nCongratulations! You win!");
				}
				else
				{
					Console.WriteLine("\nWomp-womp! It pains me to say this, but the computer demolished you!");
				}
			}
		}
	}
}
