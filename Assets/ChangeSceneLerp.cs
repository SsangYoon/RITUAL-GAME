using UnityEngine;
using System.Collections;

using Fade;
using NextScene;

namespace ChangeScene
{
	public class ChangeSceneLerp : MonoBehaviour
	{
		public GameObject _FadePlane;

		public int _SceneIndex;

		// Button Response
		public void Response()
		{
			_FadePlane.GetComponent<FadeInLerp>()._FadeIn = true;

			_FadePlane.GetComponent<NextSceneWithFadeInLerp>()._SceneIndex = _SceneIndex;
		}
	}
}
