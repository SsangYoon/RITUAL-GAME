using UnityEngine;
using System.Collections;

namespace ApplicationControll
{
	public class ExitApplication : MonoBehaviour
	{
		public bool _Exit;

		private void Update()
		{
			if (_Exit)
			{
				Application.Quit();
			}
		}
	}
}
