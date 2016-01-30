using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using DayControll;

namespace GameOver
{
	public class GameOverTextController : MonoBehaviour
	{
		private DayManager _DayManager;

		// Use this for initialization
		private void Awake()
		{
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

			this.GetComponent<Text>().text = _DayManager._PassedDay.ToString();
		}
	}
}
