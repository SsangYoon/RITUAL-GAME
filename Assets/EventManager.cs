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



			// Set Random
			int indexRandom = Random.Range(1, 6);
			int articleRandom = Random.Range(-5, 5);

			if(articleRandom >= 0)
				articleRandom++;


			// Search
			foreach (XmlNode node in _NodeList)
			{
				Debug.Log("OUT");
				if (node.SelectSingleNode("ID").InnerText == indexRandom.ToString())
				{
					Debug.Log("IN");
					// PLUS
					if (articleRandom > 0)
					{
						Debug.Log("PLUS");
						_Event.GetComponent<EventInformation>()._Index = indexRandom;
						_Event.GetComponent<EventInformation>()._Described = node.SelectSingleNode("Increase").InnerText;
						_Event.GetComponent<EventInformation>()._Article = articleRandom;
					}

					// MINUS
					else
					{
						Debug.Log("OUT");
						_Event.GetComponent<EventInformation>()._Index = indexRandom;
						_Event.GetComponent<EventInformation>()._Described = node.SelectSingleNode("Decrease").InnerText;
						_Event.GetComponent<EventInformation>()._Article = articleRandom;
					}
				}
			}

			// Set Parent
			temp.transform.SetParent(_GameCanvas.transform);
		}
	}
}
