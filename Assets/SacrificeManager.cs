using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using ResourceControll;

namespace SacrificeContoll
{
	public class SacrificeManager : MonoBehaviour
	{
		public List<int> _SacrifceList;
        public GameObject spawnFriendly;
        public CharacterInfo spawnInfo;

        public SpawnResponse[] _SpawnComponents;
        
        public void Awake()
        {
            _SacrifceList = new List<int>();
           
        }

		public void SpawnFriendly()
        {
            for (int i = 0; i < _SacrifceList.Count - 1; i++)
            {
                for (int j = 0; j < _SacrifceList.Count - 1; j++)
                {
                    if (_SacrifceList[j] > _SacrifceList[j + 1])
                    {
                        int temp = _SacrifceList[j];
                        _SacrifceList[j] = _SacrifceList[j + 1];
                        _SacrifceList[j + 1] = temp;
                    }
                }
            }
            

            while (_SacrifceList.Count < 5)
            {
                _SacrifceList.Add(0);
            }

            spawnInfo = XMLManager.Instance.Load_CharacterData(_SacrifceList[0], _SacrifceList[1], _SacrifceList[2], _SacrifceList[3], _SacrifceList[4]);

            if (spawnInfo == null)
            {
                _SacrifceList.Clear();
                return;
            }

            spawnFriendly = Instantiate(Resources.Load("Friendly/" + spawnInfo.ID)) as GameObject;

            spawnFriendly.GetComponent<Friendly>().hp = spawnInfo.HP;
            spawnFriendly.GetComponent<Friendly>().ap = spawnInfo.AP;

            for (int i = 0; i < _SpawnComponents.Length; i++)
            {
                _SpawnComponents[i]._Enabled = true;
            }

                
            Reset();	
		}

		public void Reset()
		{
			// Reset
			_SacrifceList.Clear();
		}
        
	}
}

