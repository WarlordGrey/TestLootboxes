using System.Collections.Generic;
using TestLootboxes.GameLogic.Data;

namespace TestLootboxes.GameLogic.Chest
{
	public class ChestRealContent
	{
		private List<InventoryItem> items;

		public List<InventoryItem> Items => items;

		public bool IsEmpty => items.Count == 0;

		public ChestRealContent(List<InventoryItem> newItems)
		{
			this.items = newItems;
		}

		public ChestRealContent()
		{
			this.items = new List<InventoryItem>();
		}
	}
}
