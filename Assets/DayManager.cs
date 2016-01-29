using UnityEngine;
using System.Collections;

namespace DayControll
{
	public class DayManager : MonoBehaviour {

		public bool _isDay;

		// Use this for initialization
		private void Awake () 
		{
			_isDay = true;
		}
	}
}
