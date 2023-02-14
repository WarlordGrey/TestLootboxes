using System;
using TestLootboxes.GameLogic.Data;
using TestLootboxes.UI;

namespace TestLootboxes
{
	public class Program
	{
		private static DataStorage dataStorage;

		public static void Main(string[] args)
		{
			dataStorage = new DataStorage();
			Console.WriteLine
			(
				dataStorage.PlayerData.IsFirstLaunch
				? "Welcome to looter9000!"
				: "You're back!!!"
			);
			GameLoop();
		}

		private static void GameLoop()
		{
			CommandFactory commandFactory = new CommandFactory(dataStorage);
			char nextCommand;
			while (true)
			{
				char command;
				commandFactory.ShowCommandsList();
				nextCommand = Console.ReadKey().KeyChar;
				Console.WriteLine();
				commandFactory.CreateCommand(nextCommand).DoAction();
			}
		}
	}
}
