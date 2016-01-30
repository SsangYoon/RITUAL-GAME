using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace ResourceControll
{
	public class ResourceCountController : MonoBehaviour
	{
		public int _Index;

		private ResourceManager _ResourceManager;

		private Text _Text;

		private void Awake()
		{
			// Get Component
			_ResourceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<ResourceManager>();

			_Text = this.GetComponentInChildren<Text>();
		}

		// Update is called once per frame
		private void Update()
		{
			switch (_Index)
			{
				case (int)ResourceIndex.HUMAN:
					_Text.text = _ResourceManager._Human.ToString();
					break;

				case (int)ResourceIndex.CHICKEN:
					_Text.text = _ResourceManager._Chicken.ToString();
					break;

				case (int)ResourceIndex.PIG:
					_Text.text = _ResourceManager._Pig.ToString();
					break;

				case (int)ResourceIndex.COW:
					_Text.text = _ResourceManager._Cow.ToString();
					break;

				case (int)ResourceIndex.OCTOPUS:
					_Text.text = _ResourceManager._Octopus.ToString();
					break;
			}
		}
	}
}
