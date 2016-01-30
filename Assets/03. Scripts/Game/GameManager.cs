using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DayControll;

public enum GameState
{
    Day,
    Night,
    GameClear,
    Die,
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject friendly;
    [SerializeField]
    private DayManager dayManager;
    

    public List<GameObject> enemyList { get; set; }
    public List<GameObject> friendlyList { get; set; }

    private GameState gameState;

   
    

    public void Awake()
    {
        enemyList = new List<GameObject>();
        friendlyList = new List<GameObject>();

        StartCoroutine(GameStateCheck());
    }

    IEnumerator GameStateCheck()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);

            switch(gameState)
            {
                case GameState.Day:
                    StopCoroutine(EnemySpawn());
                    break;
                case GameState.Night:
                    StartCoroutine(EnemySpawn());
                    break;
                case GameState.Die:
                    // TODO : 우리 전사가 다 죽으면 ^_^
                    break;
                case GameState.GameClear:
                    // TODO : 15일동안 버티면 ^_^
                    break;
            }
        }
    }

    IEnumerator EnemySpawn()
    {
        while(true) 
        {
            yield return new WaitForSeconds(Random.Range(3, 6));

            enemyList.Add(Instantiate(enemy, new Vector3(14, 5, 0), new Quaternion(0, 0, 0, 1)) as GameObject);
        }
    }
}
