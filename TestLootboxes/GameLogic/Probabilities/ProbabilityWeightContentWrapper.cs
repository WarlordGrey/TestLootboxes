namespace TestLootboxes.GameLogic.Probabilities
{
	public struct ProbabilityWeightContentWrapper<T> where T : IProbabilityWeightContent
	{
		public T content;
		public int lowborder;
		public int highBorder;
	}
}
