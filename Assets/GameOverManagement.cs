using UnityEngine;
using System.Collections;

namespace GameOver
{
	public class GameOverManagement : MonoBehaviour
	{
		private void Start()
		{
			// Delete DataManager
			Destroy(GameObject.FindGameObjectWithTag("DataManager"));
		}
	}

}
