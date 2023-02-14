using System;

namespace TestLootboxes.GameLogic.Probabilities
{
	public class ProbabilityExistenceContentVerificator
	{
		private static Random generator;

		private static Random Generator
		{
			get
			{
				if (generator == null)
				{
					generator = new Random();
				}
				return generator;
			}
		}

		public static bool IsExists(double probability)
		{
			return Generator.NextDouble() < probability;
		}
	}
}
