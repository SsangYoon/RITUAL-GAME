using UnityEngine;
using System.Collections;

using SacrificeContoll;

namespace Summon
{
	public class FireEffectGuide : MonoBehaviour {

		private SacrificeManager _SacrifceManager;

		private bool _Enable = false;

		// Use this for initialization
		void Awake()
		{
			_SacrifceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<SacrificeManager>();
		}

		// Update is called once per frame
		void Update()
		{
			_Enable = false;

			if (_SacrifceManager._SacrifceList.Count > 0)
				_Enable = true;

			if (_Enable)
				this.GetComponent<SpriteRenderer>().enabled = true;
			else
				this.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}

