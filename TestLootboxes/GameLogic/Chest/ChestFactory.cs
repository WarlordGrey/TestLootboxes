using System.Collections.Generic;
using TestLootboxes.GameLogic.Data;
using TestLootboxes.GameLogic.Probabilities;

namespace TestLootboxes.GameLogic.Chest
{
	class ChestFactory
	{
		private ChestRealContentFactory chestRealContentFactory;
		private ProbabilityWeightContentPool<ChestRawContent> contentPool;

		public ChestFactory(List<ChestRawContent> chestContentPrefabs, List<Item> itemsCollection)
		{
			this.contentPool = new ProbabilityWeightContentPool<ChestRawContent>(chestContentPrefabs);
			this.chestRealContentFactory = new ChestRealContentFactory(itemsCollection);
		}

		public Chest CreateChest()
		{
			return new Chest(chestRealContentFactory.CreateRealContent(contentPool.GetContent()));
		}
	}
}
