using UnityEngine;
using System.Collections;

using DayControll;

namespace ButtonMoveControll
{
	public class ButtonMoveController : MonoBehaviour
	{
		// Initialize in Inspector
		public GameObject _MoveToObject;

		public GameObject _ReturningObject;

		// Speed
		public float _Speed;

		// Day Manager
		private DayManager _DayManager;



		// Use this for initialization
		public void Start()
		{
			// Get Component
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

<<<<<<< HEAD
			// Get Property
			_GotoPosition = _MoveToObject.transform.position;
            Debug.Log(_GotoPosition);

			// Get Property
			_ReturningPosition = this.transform.position;
=======
>>>>>>> 254c2d13d17609a48d26aaaade058fe5b4747bed
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
			this.transform.position = Vector3.Lerp(this.transform.position, _ReturningObject.transform.position, _Speed * Time.deltaTime);
		}

		private void NightUpdate()
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _MoveToObject.transform.position, _Speed * Time.deltaTime);
		}
	}

}
