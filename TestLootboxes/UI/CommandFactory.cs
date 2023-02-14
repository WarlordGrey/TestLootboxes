using System;
using TestLootboxes.GameLogic.Data;

namespace TestLootboxes.UI
{
	public class CommandFactory
	{
		private const ConsoleColor cRegularColor = ConsoleColor.White;
		private const ConsoleColor cCommandsColor = ConsoleColor.Green;

		private DataStorage dataStorage;

		public CommandFactory(DataStorage dataStorage)
		{
			this.dataStorage = dataStorage;
		}

		public void ShowCommandsList()
		{
			Console.ForegroundColor = cCommandsColor;
			Console.WriteLine("Press '1' to open chest.");
			Console.WriteLine("Press '2' to show inventory.");
			Console.ForegroundColor = cRegularColor;
		}

		public Command CreateCommand(char commandKey)
		{
			switch (commandKey)
			{
				case '1':
					return new OpenChestCommand(dataStorage);
				case '2':
					return new ShowInventoryCommand(dataStorage);
				default:
					return new EmptyCommand();
			}
		}
	}
}
