using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using ResourceControll;

namespace Event
{
	public class EventInformation : MonoBehaviour
	{
		public int _Index;

		public int _Article;

		public string _Described;

		public float _Speed;

		private Image _Icon;

		private Text _CountText;

		private Text _DescribedText;

		private bool _isResponsed = false;

		private ResourceControll.ResourceManager _ResourceManager;

		public void Start()
		{
			// Resource Manager Component
			_ResourceManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<ResourceControll.ResourceManager>();

			// Image Component
			_Icon = this.transform.FindChild("Icon").GetComponent<Image>();
			
			// Text Component
			_CountText = this.transform.FindChild("Count Text").GetComponent<Text>();

			// Text Component
			_DescribedText = this.transform.FindChild("Described").GetComponent<Text>();


			// SETTING
			_Icon.sprite = Resources.Load<Sprite>("Sprites/Icon/" + _Index.ToString());

			if(_Article > 0)
				_CountText.text = ": " + "+ " + _Article.ToString();
			else
				_CountText.text = ": " + _Article.ToString();

			_DescribedText.text = _Described;

			this.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
		}

		public void Response()
		{
			_isResponsed = true;
			_ResourceManager.EventCheck(_Index, _Article);
		}

		public void Update()
		{
			this.transform.position = new Vector3(0.0f, 0.0f, -3.0f);

			if (_isResponsed == false)
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.0f, 1.0f, 1.0f), _Speed * Time.deltaTime);
			else
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), _Speed * Time.deltaTime);


			if (this.transform.localScale.magnitude <= 0.01f)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
