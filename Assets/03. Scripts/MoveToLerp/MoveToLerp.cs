using UnityEngine;
using System.Collections;

namespace MoveTo
{
	public class MoveToLerp : MonoBehaviour {
		
										// Be Chased Object
		public GameObject 				_ChasedObject;
										// Chasing Speed
		public float 					_Speed;			
		
		[SerializeField]				// StartDelay Time
		private float 					_DelayTime;		
		

		public bool					_Move;			

										// Move Completed
		public bool						_CompleteAction = false;	

		// is Staring
		private bool					_Start = false;	
		
		private void FixedUpdate ()
		{  
			if(_Move && !_Start)
				Invoke("StartMove", _DelayTime);
			
			// Move
			UpdatePosition ();
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
					_CompleteAction = true;
					return true;		// Completed Action
				}
				
				this.transform.position = Vector3.Lerp(this.transform.position, _ChasedObject.transform.position, _Speed * Time.deltaTime);
			}
			_CompleteAction = false;
			return false;		// Not Yet
		}
	}
}
