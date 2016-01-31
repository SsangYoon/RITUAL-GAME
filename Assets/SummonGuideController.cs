using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using SacrificeContoll;

namespace Summon
{
	public class SummonGuideController : MonoBehaviour
	{
		private SacrificeManager _SacrifceManager;

		private bool _Enable = false;

		// Use this for initialization
		private void Awake()
		{
			_SacrifceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<SacrificeManager>();
		}

		// Update is called once per frame
		private void Update()
		{
			_Enable = false;

			foreach (int id in _SacrifceManager._SacrifceList)
			{
				if (id == (int)ResourceIndex.HUMAN)
				{
					_Enable = true;
				}
			}

			if (_Enable)
				this.GetComponent<Image>().enabled = true;
			else
				this.GetComponent<Image>().enabled = false;
		}
	}
}
