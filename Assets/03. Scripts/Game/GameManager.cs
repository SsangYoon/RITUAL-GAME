using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DayControll;

using Fade;


public enum GameState
{
    Day,
    Night,
    GameClear,
    Die,
}

public class GameManager : MonoBehaviour
{
    private GameObject enemy;
    [SerializeField]
    private DayManager dayManager;

    [SerializeField]
    private List<int> spawnList;

    public GameObject _FadePlane;

    private int spawnIndex;

    private bool spawnFlag;
    

    public List<GameObject> enemyList { get; set; }
    public List<GameObject> friendlyList { get; set; }

    public GameState gameState;

    public StageInfo stageInfo;
    

    public void Awake()
    {
        enemyList = new List<GameObject>();
        friendlyList = new List<GameObject>();
        spawnList = new List<int>();
        dayManager = FindObjectOfType<DayManager>().GetComponent<DayManager>();

        spawnFlag = false;

        StartCoroutine(GameStateCheck());
        StartCoroutine(EnemySpawn());
    }

    IEnumerator GameStateCheck()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            

            if(dayManager._isDay)
            {
                gameState = GameState.Day;
                spawnFlag = false;
            }
            else if(!dayManager._isDay)
            {
                stageInfo = XMLManager.Instance.Load_StageData(dayManager._PassedDay - 1);
                gameState = GameState.Night;
                if(!spawnFlag)
                {
                    SetSpawnList();
                }
            }

            if (gameState == GameState.Night)
            {
                if (spawnIndex > 0)
                {
                    if (enemyList.Count > 0)
                    {
                        foreach (GameObject obj in enemyList)
                        {
                            if (obj.GetComponent<Transform>().position.x < -5)
                            {
                                gameState = GameState.Die;
                            }
                        }
                    }
                    else
                    {
                        dayManager.Day();
                    }
                }

            }

            switch(gameState)
            {
                case GameState.Day:
                    break;
                case GameState.Night:
                    break;
                case GameState.Die:
                    _FadePlane.GetComponent<NextScene.NextSceneWithFadeInLerp>()._SceneIndex = 5;
                    _FadePlane.GetComponent<FadeInLerp>()._FadeIn = true;
                    break;
                case GameState.GameClear:
                    _FadePlane.GetComponent<NextScene.NextSceneWithFadeInLerp>()._SceneIndex = 5;
                    _FadePlane.GetComponent<FadeInLerp>()._FadeIn = true;
                    break;
            }
        }
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 3));
            if (gameState == GameState.Night)
            {
                if(spawnIndex < stageInfo.Sum)
                {
                    EnemyInfo temp = XMLManager.Instance.Load_EnemyData(spawnList[spawnIndex]);
                    if (temp == null)
                    {
                        Debug.Log("EnemyInfo NULL");
                    }
                    enemy = Instantiate(Resources.Load("Enemy/" + temp.ID), new Vector3(20, 5, 0), new Quaternion(0, 0, 0, 1)) as GameObject;
                    enemyList.Add(enemy);

                    enemy.GetComponent<Enemy>().hp = temp.HP;
                    enemy.GetComponent<Enemy>().ap = temp.AP;

                    spawnIndex++;
                }
            }
        }
    }

    private void SetSpawnList()
    {
        spawnList.Clear();
        if(dayManager._PassedDay < 11)
        {
            for (int i = 0; i < stageInfo.Enemy1; i++)
            {
                spawnList.Add(0);
            }
            for (int i = 0; i < stageInfo.Enemy2; i++)
            {
                spawnList.Add(1);
            }
            for (int i = 0; i < stageInfo.Enemy3; i++)
            {
                spawnList.Add(2);
            }
            for (int i = 0; i < stageInfo.Enemy4; i++)
            {
                spawnList.Add(3);
            }
            for (int i = 0; i < stageInfo.Enemy5; i++)
            {
                spawnList.Add(4);
            }

            int it = 0;
            // shuffle
            while (it < spawnList.Count)
            {
                int r = Random.Range(0, spawnList.Count);

                int temp = spawnList[it];
                spawnList[it] = spawnList[r];
                spawnList[r] = temp;

                it++;
            }
        }
        else
        {
            for(int i = 0; i < stageInfo.Sum; i++)
            {
                spawnList.Add(Random.Range(0, 5));
            }
        }

        spawnIndex = 0;
        spawnFlag = true;
    }

    
}
