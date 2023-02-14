using System;
using TestLootboxes.GameLogic.Chest;
using TestLootboxes.GameLogic.Data;

namespace TestLootboxes.UI
{
	class OpenChestCommand : Command
	{
		private const int cChestsMaxCount = 3;

		private DataStorage dataStorage;
		private ChestFactory chestFactory;
		private Chest[] chests;

		public OpenChestCommand(DataStorage dataStorage)
		{
			this.dataStorage = dataStorage;
			this.chestFactory = new ChestFactory(dataStorage.ChestRawContentCollection, dataStorage.ItemsCollection);
		}

		public override void DoAction()
		{
			GenerateChests();
			Console.WriteLine("You can see 3 chests in front of you. Pick a number from 1 to 3");
			char chestKey = Console.ReadKey().KeyChar;
			Console.WriteLine();
			OpenChest(chestKey);
			dataStorage.SavePlayerData();
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
			Console.WriteLine();
		}

		private void GenerateChests()
		{
			chests = new Chest[cChestsMaxCount];
			for (int i = 0; i < chests.Length; i++)
			{
				chests[i] = chestFactory.CreateChest();
			}
		}

		private void OpenChest(char chestKey)
		{
			int pickedChest = chestKey - '1';
			if ((pickedChest < 0) || (pickedChest > chests.Length))
			{
				Console.WriteLine("You tried to cheat! So now you will be opening first chest!");
				pickedChest = 0;
			}
			Console.WriteLine("Attempt to open chest {0}!", pickedChest + 1);
			if (chests[pickedChest].Content.IsEmpty)
			{
				Console.WriteLine("Sorry! Chest was empty!");
			}
			else
			{
				foreach (InventoryItem cur in chests[pickedChest].Content.Items)
				{
					Console.WriteLine(string.Format
					(
						"{0} (amount: {1}) added to your inventory!",
						dataStorage.GetItemById(cur.itemId).name,
						cur.amount
					));
					dataStorage.PlayerData.Inventory.AddItem(cur);
				}
			}
			ShowOtherChests(pickedChest);
		}

		private void ShowOtherChests(int pickedChest)
		{
			Console.WriteLine("Now lets see what other chests contained...");
			for (int i = 0; i < chests.Length; i++)
			{
				if (i == pickedChest)
				{
					continue;
				}
				Console.WriteLine("Chest {0}:", i + 1);
				if (chests[i].Content.IsEmpty)
				{
					Console.WriteLine("Chest was empty! :D");
				}
				else
				{
					foreach (InventoryItem cur in chests[i].Content.Items)
					{
						Console.WriteLine(string.Format
						(
							"{0} (amount: {1}) was there!",
							dataStorage.GetItemById(cur.itemId).name,
							cur.amount
						));
					}
				}
			}
		}
	}
}
