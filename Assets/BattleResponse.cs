using UnityEngine;
using System.Collections;

using DayControll;

namespace BattleControll
{
	public class BattleResponse : MonoBehaviour
	{
		private DayManager _DayManager;

		// Use this for initialization
		private	void Awake()
		{
			// Get Component	
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();
		}

		// Button Response
		public void BattleButtonResponse()
		{
			_DayManager.Night();
		}
	}
}
