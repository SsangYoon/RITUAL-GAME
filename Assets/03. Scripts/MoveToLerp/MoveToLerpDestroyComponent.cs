using UnityEngine;
using System.Collections;
	
namespace MoveTo
{
	public class MoveToLerpDestroyComponent : MonoBehaviour {

		// Be Chased Object
		public GameObject 				_ChasedObject;
		
		[SerializeField]
		public float 					_Speed;			// Chasing Speed
		
		[SerializeField]
		public float 					_DelayTime;		// StartDelay Time
		
		[SerializeField]
		public bool						_Move;			// Move On, Off
		
	
		public bool						_CompleteAction = false;	// Completed Action


		private bool					_Start = false;	// Staring
		
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
					Destroy(this);	// Destory This Component
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
