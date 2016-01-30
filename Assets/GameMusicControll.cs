using UnityEngine;
using System.Collections;

public class GameMusicControll : MonoBehaviour {

	public AudioSource _AudioSource;

	public AudioClip _DayMusic;

	public AudioClip _NightMusic;

	private DayControll.DayManager _DayManager;

	private bool _isChange = false;

	private bool _isDay = true;

	private void Awake()
	{
		// Setting Loop
		_AudioSource.loop = true;
		_AudioSource.clip = _DayMusic;
		_AudioSource.Play();

		// Get Component
		_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayControll.DayManager>();
	}

	// Update is called once per frame
	private void Update ()
	{
		if (_isDay == true)
		{
			if (_DayManager._isDay == false)
			{
				_isChange = true;
				_isDay = false;
			}
		}
		else
		{
			if (_DayManager._isDay == true)
			{
				_isChange = true;
				_isDay = true;
			}
		}

		// is Change
		if (_isChange)
		{
			if (_isDay)
			{
				_AudioSource.clip = _DayMusic;
				_AudioSource.volume = 1.0f;

				_AudioSource.Play();
			}
			else
			{
				_AudioSource.clip = _NightMusic;
				_AudioSource.volume = 0.5f;
				_AudioSource.Play();
			}

			_isChange = false;
		}
	}
}
