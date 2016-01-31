using UnityEngine;
using System.Collections;

namespace ApplicationControll
{
	public class ExitApplication : MonoBehaviour
	{
		public bool _Exit;

        private void Awake()
        {
            Invoke("ExitAPP", 1.5f);
        }

        private void ExitAPP()
        {

            Application.Quit();

        }
	}
}
