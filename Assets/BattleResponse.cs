using UnityEngine;
using System.Collections;

using MoveTo;
using DayControll;

namespace BattleControll
{
	public class BattleResponse : MonoBehaviour
	{
		public GameObject _Camera;

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
			// Set Night
			_DayManager.Night();
		}
	}
}
