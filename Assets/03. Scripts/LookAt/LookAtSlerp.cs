using UnityEngine;
using System.Collections;

namespace LookAt
{
	public class LookAtSlerp : MonoBehaviour {
		
		public GameObject		_LookedObject;		// Looking GmaeObject
		
		public bool				_Look;				// is Look On?

		public float			_Speed;				// Look Speed

		public float			_Delaytime;			// DelayTime
		
		private bool			_Start = false;		// is Look Start

		private void Start()
		{
			if(_Look)
				Invoke("LookStart", _Delaytime);
		}
		
		private void Update () 
		{
			if(_Look && _Start)					// Look, Start
			{
				if(_LookedObject != null)		// Null Check
				{
					Look();
				}
			}
		}

		private void LookStart()
		{
			_Start = true;
		}
		
		// Looking Slerp
		private void Look()
		{
			// Slerp Rotation
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
			                                           _LookedObject.transform.rotation,
			                                           _Speed * Time.deltaTime);
		}
	}
}
