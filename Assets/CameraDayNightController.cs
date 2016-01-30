using UnityEngine;
using System.Collections;

using DayControll;

public class CameraDayNightController : MonoBehaviour {

	public GameObject _MovePosition;

	public float _Speed;

	private Vector3 _ReturningPoint;

	private DayManager _DayManager;


	void Awake()
	{
		_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

		_ReturningPoint = this.transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_DayManager._isDay == false)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _MovePosition.transform.position, _Speed * Time.deltaTime);
		}
		else
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _ReturningPoint, _Speed * Time.deltaTime);
		}
	}
}
