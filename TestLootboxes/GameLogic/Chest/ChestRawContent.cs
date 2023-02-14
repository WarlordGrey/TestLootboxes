using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TestLootboxes.GameLogic.Data;
using TestLootboxes.GameLogic.Probabilities;

namespace TestLootboxes.GameLogic.Chest
{
	[Serializable]
	public class ChestRawContent : IProbabilityWeightContent
	{
		public List<InventoryItem> items;
		public int chestWeight;

		[JsonIgnore]
		public int ProbabilityWeight => chestWeight;
	}
}
