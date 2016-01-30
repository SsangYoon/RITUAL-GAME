using UnityEngine;
using System.Collections;

using Event;
using SacrificeContoll;

namespace DayControll
{
	public class DayManager : MonoBehaviour {

		public bool _isDay;

		public int _PassedDay = 1;

		private SacrificeManager _SacrificeManager;
		
		// Use this for initialization
		private void Awake () 
		{
			_isDay = true;
			_SacrificeManager = this.GetComponent<SacrificeManager>();
		}

		public void Day()
		{
			if (_isDay == false)
			{
				this.GetComponent<EventManager>().EventSpawn();
				_PassedDay++;
			}
			_isDay = true;
		}

		public void Night()
		{
			_SacrificeManager.Reset();

			_isDay = false;
		}

		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Q))
			{
				Day();
			}
			else if (Input.GetKeyUp(KeyCode.E))
			{
				Night();
			}
		}
	}
}
