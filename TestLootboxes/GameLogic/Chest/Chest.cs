namespace TestLootboxes.GameLogic.Chest
{
	public class Chest
	{
		private ChestRealContent content;

		public ChestRealContent Content => content;

		public Chest(ChestRealContent newContent)
		{
			this.content = newContent;
		}
	}
}
