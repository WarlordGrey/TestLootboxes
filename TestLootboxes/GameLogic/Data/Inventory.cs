using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestLootboxes.GameLogic.Data
{
	[Serializable]
	public class Inventory
	{
		[JsonProperty]
		private List<InventoryItem> items;

		[JsonIgnore]
		public List<InventoryItem> Items => this.items;

		[JsonIgnore]
		public bool IsEmpty => items.Count == 0;

		public Inventory()
		{
			this.items = new List<InventoryItem>();
		}

		public void AddItem(InventoryItem item)
		{
			foreach (InventoryItem cur in items)
			{
				if (cur.itemId == item.itemId)
				{
					cur.amount += item.amount;
					return;
				}
			}
			items.Add(new InventoryItem(item));
		}
	}
}
