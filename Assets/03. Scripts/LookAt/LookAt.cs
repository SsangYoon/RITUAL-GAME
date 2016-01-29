using UnityEngine;
using System.Collections;

namespace LookAt
{
	public class LookAt : MonoBehaviour {

		public GameObject		_LookedObject;		// Looking GmaeObject

		public bool				_Look;				// is Look On?

		private bool			_Start = false;		// is Look Start

		public float			_Delytime;			// DelayTime


		private void Stat()
		{
			if(_Look)
				Invoke("LookStart", _Delytime);
		}

		// Update is called once per frame
		void Update () 
		{
			if(_Look && _Start)
				Look();
		}

		private void LookStart()
		{
			_Start = true;
		}

		// Looking
		private void Look()
		{
			if(_LookedObject != null)
				this.transform.LookAt(_LookedObject.transform.position);
		}
	}
}
