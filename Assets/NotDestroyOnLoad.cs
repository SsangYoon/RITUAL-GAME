using UnityEngine;
using System.Collections;

namespace GameObjectControll
{
	public class NotDestroyOnLoad : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}
}
