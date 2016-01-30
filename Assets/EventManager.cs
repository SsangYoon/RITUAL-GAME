using UnityEngine;
using UnityEngine.UI;

using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Event
{
	public class EventManager : MonoBehaviour
	{
		public GameObject _GameCanvas;

		public GameObject _Event;

		public List<string> _IncreaseEvent;

		public List<string> _DecreaseEvent;

		private string _FileName = "EventText";

		private XmlNodeList _NodeList;

		private void Awake()
		{
			// New TextAsset
			TextAsset textAsset = Resources.Load("XML/" + _FileName) as TextAsset;

			// New XML Document
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(textAsset.text);

			// Get XML Node List
			_NodeList = xmlDoc.SelectNodes("Event/Described");
		}


		public void EventSpawn()
		{
			// Instantiate
			GameObject temp = Instantiate(_Event);

			int indexRandom = Random.Range(0, 5);
			int articleRandom = Random.Range(-5, 5);

			if(articleRandom >= 0)
				articleRandom++;


			// Search
			foreach (XmlNode node in _NodeList)
			{
				Debug.Log(_NodeList.Count);
				Debug.Log(node.SelectSingleNode("ID").InnerText);
				if (node.SelectSingleNode("ID").InnerText == indexRandom.ToString())
				{
					// PLUS
					if (articleRandom > 0)
					{
						_Event.GetComponentInChildren<Text>().text = node.SelectSingleNode("Increase").InnerText;
					}

					// MINUS
					else
					{
						_Event.GetComponentInChildren<Text>().text = node.SelectSingleNode("Decrease").InnerText;
					}
				}
			}


			// Apply to Resource Manager
			this.GetComponent<ResourceControll.ResourceManager>().EventCheck(indexRandom, articleRandom);

			// Set Parent
			temp.transform.SetParent(_GameCanvas.transform);
		}
	}
}
