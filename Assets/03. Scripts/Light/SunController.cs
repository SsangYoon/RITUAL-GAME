using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

	[SerializeField]
	private float m_TimeAngle;

	// Use this for initialization
	void Start () 
	{
		Init_TimeAngle ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Update_SunAngle ();
	}

	void Init_TimeAngle()
	{
		m_TimeAngle = 0.5f;
	}

	void Update_SunAngle()
	{
		transform.Rotate(new Vector3(m_TimeAngle, 0.0f, 0.0f) * Time.deltaTime);
	}
}
