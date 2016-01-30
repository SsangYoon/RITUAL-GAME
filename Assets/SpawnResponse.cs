using UnityEngine;
using System.Collections;

using SacrificeContoll;

namespace ResourceControll
{
	public class SpawnResponse : MonoBehaviour
	{
		public int _Index;

		private SacrificeManager _SacrificeManager;

		private ResourceManager _ResourceManager;

		private void Awake()
		{
			// Get Component
			_SacrificeManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<SacrificeManager>();

			_ResourceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<ResourceManager>();
		}

		public void SpawnButtonResponse()
		{
			if (_SacrificeManager._SacrifceList.Count >= 5.0f)
				return;

			switch (_Index)
			{
				case (int)ResourceIndex.HUMAN:
					if (_ResourceManager._Human <= 0)
						return;
					_ResourceManager._Human--;
					break;

				case (int)ResourceIndex.CHICKEN:
					if (_ResourceManager._Chicken <= 0)
						return;
					_ResourceManager._Chicken--;
					break;

				case (int)ResourceIndex.PIG:
					if (_ResourceManager._Pig <= 0)
						return;
					_ResourceManager._Pig--;
					break;

				case (int)ResourceIndex.COW:
					if (_ResourceManager._Cow <= 0)
						return;
					_ResourceManager._Cow--;
					break;

				case (int)ResourceIndex.OCTOPUS:
					if (_ResourceManager._Octopus <= 0)
						return;
					_ResourceManager._Octopus--;
					break;
			}
			_SacrificeManager._SacrifceList.Add(_Index.ToString());
		}
	}
}
