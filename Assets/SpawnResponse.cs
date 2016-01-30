using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using SacrificeContoll;

namespace ResourceControll
{
	public class SpawnResponse : MonoBehaviour
	{
		public int _Index;

		private SacrificeManager _SacrificeManager;

		private ResourceManager _ResourceManager;

		private DayControll.DayManager _DayManager;

		private bool _NightCheck = false;

		private void Awake()
		{
			// Get Component
			_SacrificeManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<SacrificeManager>();

			_ResourceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<ResourceManager>();

			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayControll.DayManager>();
		}

		public void SpawnButtonResponse()
		{
<<<<<<< HEAD
			if (_SacrificeManager._SacrifceList.Count >= 5)
=======
			// Check
			if (_SacrificeManager._SacrifceList.Count >= 5.0f)
>>>>>>> 254c2d13d17609a48d26aaaade058fe5b4747bed
				return;


			// Check
			foreach (string str in _SacrificeManager._SacrifceList)
			{
				if (str == _Index.ToString())
				{
					Debug.Log("Disable Chek");
					// Disable
					return;
				}
			}

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

			this.GetComponent<Image>().color = new Color(100.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 1.0f);

			_SacrificeManager._SacrifceList.Add(_Index.ToString());
		}

		// Disable Button
		public void Update()
		{
			if (_NightCheck == false)
			{
				if (_DayManager._isDay == false)
				{
					_NightCheck = true;
					this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				}
			}
			else
			{
				if (_DayManager._isDay == true)
				{
					_NightCheck = false;
				}
			}
		}
	}
}
