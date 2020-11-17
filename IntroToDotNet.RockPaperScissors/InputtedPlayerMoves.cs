using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToDotNet.RockPaperScissors
{
	public class InputtedPlayerMoves
	{
		public List<PlayerMoveInput> Imports { get; set; } = new List<PlayerMoveInput>();

		public StringBuilder Errors { get; } = new StringBuilder();

		public async Task<bool> Populate(string fileImportName)
		{
			if (!File.Exists(fileImportName))
				throw new Exception($"File input does not exist - {fileImportName}.");

			var lines = await File.ReadAllLinesAsync(fileImportName);

			foreach (var line in lines)
			{
				var splitLine = line.Split(',');

				if (splitLine.Length != 3)
				{
					Errors.AppendLine($"Too many or too few values found for line {line}.");
					continue;
				}

				bool containsErrors = false;

				var name = splitLine[0].Trim();

				if (string.IsNullOrWhiteSpace(name))
				{
					Errors.AppendLine("A name must be provided.");
					containsErrors = true;
				}

				var moveStr = splitLine[1].Trim();

				if (!Enum.IsDefined(typeof(Move), moveStr))
				{
					Errors.AppendLine($"An invalid value for determining a Move was found: {moveStr}");
					containsErrors = true;
				}

				var numberOfRoundsString = splitLine[2].Trim();

				if (!int.TryParse(numberOfRoundsString, out int numberOfRounds))
				{
					Errors.AppendLine($"{numberOfRoundsString} is not a valid numerical value.");
				}

				if (containsErrors)
				{
					continue;
				}

				Imports.Add(new PlayerMoveInput { Name = name, Move = Enum.Parse<Move>(moveStr), NumberOfRounds = numberOfRounds});
			}

			return Imports.Any();
		}
	}

	public class PlayerMoveInput
	{
		public string Name { get; set; }

		public Move Move { get; set; }

		public int NumberOfRounds { get; set; }
	}
}