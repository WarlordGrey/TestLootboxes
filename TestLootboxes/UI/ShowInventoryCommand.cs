using System;
using TestLootboxes.GameLogic.Data;

namespace TestLootboxes.UI
{
	public class ShowInventoryCommand : Command
	{
		private DataStorage dataStorage;

		public ShowInventoryCommand(DataStorage dataStorage)
		{
			this.dataStorage = dataStorage;
		}

		public override void DoAction()
		{
			if (dataStorage.PlayerData.Inventory.IsEmpty)
			{
				Console.WriteLine("Your inventory is empty!!!");
				return;
			}
			Console.WriteLine("Currently player has:");
			foreach (InventoryItem cur in dataStorage.PlayerData.Inventory.Items)
			{
				Console.WriteLine(string.Format("{0} (amount: {1})", dataStorage.GetItemById(cur.itemId).name, cur.amount));
			}
			Console.WriteLine("That all in your inventory!");
		}
	}
}
