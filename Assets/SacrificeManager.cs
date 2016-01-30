using UnityEngine;

using System.Collections;
using System.Collections.Generic;


namespace SacrificeContoll
{
	public class SacrificeManager : MonoBehaviour
	{
		public List<string> _SacrifceList;

		public void SpawnFreindly()
		{

			// Reset
			_SacrifceList.Clear();
		}
	}
}

