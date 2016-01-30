using UnityEngine;
using System.Collections;

enum ResourceIndex
{
	EMPTY = 0,
	HUMAN = 1,
	CHICKEN = 2,
	PIG = 3,
	COW = 4,
	OCTOPUS = 5,
};


namespace ResourceControll
{
	public class ResourceManager : MonoBehaviour
	{
		// Leveling on Inspector
		public int _Human;

		public int _Chicken;

		public int _Pig;

		public int _Cow;

		public int _Octopus;


		public void EventCheck(int id, int article)
		{
			switch (id)
			{
				case (int)ResourceIndex.HUMAN:
					_Human += article;
					break;

				case (int)ResourceIndex.CHICKEN:
					_Chicken += article;
					break;

				case (int)ResourceIndex.PIG:
					_Pig += article;
					break;

				case (int)ResourceIndex.COW:
					_Cow += article;
					break;

				case (int)ResourceIndex.OCTOPUS:
					_Octopus += article;
					break;
			}
		}
	}
}

