using UnityEngine;
using System.Collections;

using Event;

namespace DayControll
{
	public class DayManager : MonoBehaviour {

		public bool _isDay;

		private int _PassedDay = 1;

		// Use this for initialization
		private void Awake () 
		{
			_isDay = true;
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
			_isDay = false;
		}
	
	}
}
