using System.Collections.Generic;
using TestLootboxes.GameLogic.Data;
using TestLootboxes.GameLogic.Probabilities;

namespace TestLootboxes.GameLogic.Chest
{
	public class ChestRealContentFactory
	{
		private List<Item> itemsCollection;

		public ChestRealContentFactory(List<Item> itemsCollection)
		{
			this.itemsCollection = itemsCollection;
		}

		public ChestRealContent CreateRealContent(ChestRawContent content)
		{
			if(content == null)
			{
				return new ChestRealContent();
			}
			List<InventoryItem> realItems = new List<InventoryItem>();
			foreach (InventoryItem cur in content.items)
			{
				Item realItem = itemsCollection.Find(i => i.id == cur.itemId);
				if (ProbabilityExistenceContentVerificator.IsExists(realItem.existenceChance))
				{
					realItems.Add(cur);
				}
			}
			return new ChestRealContent(realItems);
		}
	}
}
