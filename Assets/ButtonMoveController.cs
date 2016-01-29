using UnityEngine;
using System.Collections;

using DayControll;

namespace ButtonMoveControll
{
	public class ButtonMoveController : MonoBehaviour
	{
		// Initialize in Inspector
		public GameObject _MoveToObject;

		public float _Speed;

		private DayManager _DayManager;

		private Vector3 _GotoPosition;

		private Vector3 _ReturningPosition;




		// Use this for initialization
		private void Awake()
		{
			// Get Component
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

			// Get Property
			_GotoPosition = _MoveToObject.transform.position;

			// Get Property
			_ReturningPosition = this.transform.position;
		}

		// Update is called once per frame
		private void Update()
		{
			UpdateSpawnButton();
		}

		private void UpdateSpawnButton()
		{
			// Day
			if (_DayManager._isDay)
				DayUpdate();

			// Night
			else
				NightUpdate();
		}

		private void DayUpdate()
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _ReturningPosition, _Speed * Time.deltaTime);
		}

		private void NightUpdate()
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _GotoPosition, _Speed * Time.deltaTime);
		}
	}

}
