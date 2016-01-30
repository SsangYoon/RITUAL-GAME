using UnityEngine;
using System.Collections;

using SizeControll;

namespace EventDescribed
{
	public class EventDescribedResponse : MonoBehaviour
	{
		private SizeControllLerp _SizeController;

		private bool _isResponse = false;

		public void Start()
		{
			_SizeController = this.GetComponent<SizeControllLerp>();

			_SizeController._DirectionSize = new Vector3(1.0f, 1.0f, 1.0f);

			_SizeController._SizeControll = true;
		}

		public void Response()
		{
			_isResponse = true;

			_SizeController._DirectionSize = new Vector3(0.0f, 0.0f, 0.0f);

			_SizeController._SizeControll = true;
		}

		private void Update()
		{
			// Response Check
			if (_isResponse == false)
				return;


			if (this.transform.localScale.x <= 0.01f &&
			   this.transform.localScale.y <= 0.01f &&
			   this.transform.localScale.z <= 0.01f)
			{
				Destroy(this.gameObject);
			}
		}
	}
}

