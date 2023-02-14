using System;
using Newtonsoft.Json;

namespace TestLootboxes.GameLogic.Data
{
	[Serializable]
	public class InventoryItem
	{
		public int itemId;
		public int amount;

		[JsonConstructor]
		public InventoryItem(int newItemId, int newAmount = 1)
		{
			this.itemId = newItemId;
			this.amount = newAmount;
		}

		public InventoryItem(InventoryItem origin)
		{
			this.itemId = origin.itemId;
			this.amount = origin.amount;
		}
	}
}
