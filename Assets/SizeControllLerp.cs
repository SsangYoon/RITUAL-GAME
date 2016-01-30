using UnityEngine;
using System.Collections;

namespace SizeControll
{
	public class SizeControllLerp : MonoBehaviour
	{
		// ON OFF
		public bool _SizeControll;

		// SIZE
		public Vector3 _DirectionSize;

		// SPEED
		public float _Speed;

		// StartDelay Time
		[SerializeField] private float _DelayTime;

		// IS COMPLETE
		public bool _CompleteAction = false;

		// IS STARTED
		private bool _Start = false;

		// Update is called once per End frame
		private void FixedUpdate()
		{
			if (_SizeControll && !_Start)
				Invoke("StartSizeControll", _DelayTime);

			// Move
			_CompleteAction = UpdateSize();
		}

		// Turn On Start Property
		private void StartSizeControll()
		{
			_Start = true;
		}

		private bool UpdateSize()
		{
			if (_Start && _SizeControll)
			{
				// Almost Attach
				if (Mathf.Abs(this.transform.localScale.x - _DirectionSize.x) <= 0.1f &&
					Mathf.Abs(this.transform.localScale.y - _DirectionSize.y) <= 0.1f &&
					Mathf.Abs(this.transform.localScale.z - _DirectionSize.z) <= 0.1f)
				{
					return true;		// Completed Action
				}

				// Size Update
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, _DirectionSize, _Speed * Time.deltaTime);
			}
			return false;		// Not Yet
		}
	}
}
