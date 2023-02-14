using System;
using Newtonsoft.Json;

namespace TestLootboxes.GameLogic.Data
{
	[Serializable]
	public class PlayerData
	{
		[JsonProperty]
		private Inventory inventory;
		[JsonProperty]
		private int launches;

		[JsonIgnore]
		public bool IsFirstLaunch => launches == 1;

		[JsonIgnore]
		public Inventory Inventory => inventory;

		public PlayerData()
		{
			this.inventory = new Inventory();
			this.launches = 1;
		}

		public void AnotherLaunch()
		{
			launches++;
		}
	}
}
