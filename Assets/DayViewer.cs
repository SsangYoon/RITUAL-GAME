using UnityEngine;
using System.Collections;


namespace DayControll
{
	public class DayViewer : MonoBehaviour
	{
		private DayManager _DayManager;

		// Use this for initialization
		private void Awake()
		{
			// Get Component
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();
		}

		// Update is called once per frame
		private void Update()
		{
			this.GetComponent<UnityEngine.UI.Text>().text = "DAY " + _DayManager._PassedDay.ToString();
		}
	}
}
