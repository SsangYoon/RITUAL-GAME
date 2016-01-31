using UnityEngine;
using System.Collections;

namespace WaveMove
{
	public class WaveMoveY : MonoBehaviour
	{
		public float _Speed;

		public float _WaveScale;

		private float _DeltaTime = 0.0f;

		// Update is called once per frame
		private void Update()
		{
			_DeltaTime += Time.deltaTime;
			float offset = Mathf.Sin(_DeltaTime * _Speed);
			offset *= _WaveScale;

			Vector3 position = this.transform.position;
			position.y += offset;

			this.transform.position = position;
		}
	}
}
