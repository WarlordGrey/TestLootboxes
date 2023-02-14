using System;
using System.ComponentModel.DataAnnotations;

namespace TestLootboxes.GameLogic.Data
{
	[Serializable]
	public class Item
	{
		public int id;
		public string name;
		[Range(0, 1)]
		public double existenceChance;
	}
}
