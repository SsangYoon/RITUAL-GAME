using UnityEngine;
using System.Collections;

using DayControll;
using UnityStandardAssets.ImageEffects;

namespace Vignette
{
	public class VignetteController : MonoBehaviour
	{
		public DayManager _DayManager;

		public float _Speed;

		private bool _isDay;

		private float _MaximumIntensity;


		// Use this for initialization
		private void Start()
		{
			_DayManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DayManager>();

			_MaximumIntensity = this.GetComponent<VignetteAndChromaticAberration>().intensity;

			this.GetComponent<VignetteAndChromaticAberration>().intensity = 0.0f;
		}

		// Update is called once per frame
		private void Update()
		{
			_isDay = _DayManager._isDay;

			UpdateVignette();
		}

		private void UpdateVignette()
		{
			if (_isDay)
				TurnOffVignette();

			else
				TurnOnVignette();
		}

		// ON
		private void TurnOnVignette()
		{
			float intensity = this.GetComponent<VignetteAndChromaticAberration>().intensity;

			this.GetComponent<VignetteAndChromaticAberration>().intensity = Mathf.Lerp(intensity, _MaximumIntensity, _Speed * Time.deltaTime);
		}

		// OFF
		private void TurnOffVignette()
		{
			float intensity = this.GetComponent<VignetteAndChromaticAberration>().intensity;

			this.GetComponent<VignetteAndChromaticAberration>().intensity = Mathf.Lerp(intensity, 0.0f, _Speed * Time.deltaTime);
		}
	}
}

