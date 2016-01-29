using UnityEngine;
using System.Collections;

namespace MoveTo
{
	public class MoveToLerpDestroyGameObject : MonoBehaviour {
		
		public GameObject 				_ChasedObject;	// Be Chased Object
		
		public float 					_Speed;			// Chasing Speed

		public float 					_DelayTime;		// StartDelay Time

		public bool						_Move;			// Move On, Of

		public bool						_CompleteAction = false;	// Completed Action

		private bool					_Start = false;	// Staring
		
		private void FixedUpdate ()
		{  
			if(_Move && !_Start)
				Invoke("StartMove", _DelayTime);
			
			if(_ChasedObject != null)
				UpdatePosition ();		// Move
		}

		// Turn On Start Property
		private void StartMove()
		{
			_Start = true;
		}

		// Calculating and Move
		private bool UpdatePosition ()
		{
			if(_Start && _Move)
			{
				// Almost Attach
				if(Mathf.Abs(this.transform.position.x - _ChasedObject.transform.position.x) <= 0.1f &&
				   Mathf.Abs(this.transform.position.y - _ChasedObject.transform.position.y) <= 0.1f)
				{
					Destroy(this.gameObject);		// Destroy this GameObject
					_CompleteAction = true;
					return true;
				}
				
				this.transform.position = Vector3.Lerp(this.transform.position, _ChasedObject.transform.position, _Speed * Time.deltaTime);
			}
			_CompleteAction = false;
			return false;
		}
	}
}
