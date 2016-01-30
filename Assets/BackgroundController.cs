using UnityEngine;
using System.Collections;

using DayControll;

namespace BackgroundControll
{
	public class BackgroundController : MonoBehaviour
	{
		private DayManager _DayManager;

		private bool _isDay;

		// Initialize in Inspector
		public float _Speed;
		
		public SpriteRenderer _Day;

		public SpriteRenderer _Night;


		// Use this for initialization
		private void Awake()
		{
			// Get Component
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

			// Get Property
			_isDay = _DayManager._isDay;
		}

		// Update is called once per frame
		private void Update()
		{
			// Get Property
			_isDay = _DayManager._isDay;

			UpdateBackground();
		}

		private void UpdateBackground()
		{
			if(_isDay)
				GettingDay();
			else
				GettingNight();
		}

		// Getting Bright
		private void GettingDay()
		{
			// Fade In
			float alpha = _Day.color.a;

			float offset = Mathf.Lerp(alpha, 1.0f, _Speed * Time.deltaTime);

			Color color = new Color(1.0f, 1.0f, 1.0f, offset);

			_Day.color = color;

			// Fade Out
			_Night.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - color.a);
		}

		// Getting Dark
		private void GettingNight()
		{
			// Fade In
			float alpha = _Night.color.a;

			float offset = Mathf.Lerp(alpha, 1.0f, _Speed * Time.deltaTime);

			Color color = new Color(1.0f, 1.0f, 1.0f, offset);

			_Night.color = color;

			// Fade Out
			_Day.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - color.a);
		}
	}

}
