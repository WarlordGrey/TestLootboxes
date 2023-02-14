using System;
using System.Collections.Generic;

namespace TestLootboxes.GameLogic.Probabilities
{
	public class ProbabilityWeightContentPool<T> where T : IProbabilityWeightContent
	{
		private List<ProbabilityWeightContentWrapper<T>> wrappedContent;
		private int totalWeightSum;
		private Random generator;

		public ProbabilityWeightContentPool(List<T> content)
		{
			this.wrappedContent = new List<ProbabilityWeightContentWrapper<T>>();
			int lastBorder = -1;
			this.totalWeightSum = 0;
			foreach (T cur in content)
			{
				ProbabilityWeightContentWrapper<T> newItem;
				newItem.content = cur;
				newItem.lowborder = lastBorder + 1;
				newItem.highBorder = lastBorder + cur.ProbabilityWeight;
				lastBorder = newItem.highBorder;
				this.wrappedContent.Add(newItem);
			}
			this.totalWeightSum = lastBorder;
			this.generator = new Random();
		}

		public T GetContent()
		{
			int foundVal = generator.Next(0, totalWeightSum + 1);
			foreach (ProbabilityWeightContentWrapper<T> cur in wrappedContent)
			{
				if ((foundVal >= cur.lowborder) && (foundVal <= cur.highBorder))
				{
					return cur.content;
				}
			}
			return default(T);
		}
	}
}
