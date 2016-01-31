using UnityEngine;
using System.Collections;

using Event;
using SacrificeContoll;

namespace DayControll
{
	public class DayManager : MonoBehaviour {

		public bool _isDay;

		public int _PassedDay = 1;

		private SacrificeManager _SacrificeManager;
        private GameManager gameManager;
		
		// Use this for initialization
		private void Awake () 
		{
			_isDay = true;
			_SacrificeManager = this.GetComponent<SacrificeManager>();
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            
		}

		public void Day()
		{
			if (_isDay == false)
			{
				this.GetComponent<EventManager>().EventSpawn();
				_PassedDay++;
                if(gameManager.friendlyList.Count > 0)      // 날이 바뀌면 아군 증발
                {
                    for (int i = 0; i < gameManager.friendlyList.Count; i++)
                    {
                        gameManager.friendlyList.Remove(this.gameObject);
                        DestroyObject(gameManager.friendlyList[i].gameObject);
                    }
                }
                gameManager.friendlyList.Clear();
			}
			_isDay = true;
		}

		public void Night()
		{
			_SacrificeManager.Reset();

			_isDay = false;

            for (int i = 0; i < gameManager.friendlyList.Count; i++)
            {
                gameManager.friendlyList[i].GetComponent<FriendlyAction>().state = CharState.Move;
            }

        }

		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Q))
			{
				Day();
			}
			else if (Input.GetKeyUp(KeyCode.E))
			{
				Night();
			}
		}
	}
}
