using UnityEngine;
using System.Collections;

using SacrificeContoll;

namespace ResourceControll
{
	public class SpawnResponse : MonoBehaviour
	{
		public int _Index;

		private SacrificeManager _SacrificeManager;

		private void Awake()
		{
			// Get Component
			_SacrificeManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<SacrificeManager>();
		}

		public void SpawnButtonResponse()
		{

		}

		// Update is called once per frame
		private void Update()
		{

		}
	}
}
