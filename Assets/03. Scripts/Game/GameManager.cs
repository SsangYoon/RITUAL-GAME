using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject friendly;

    public List<GameObject> enemyList { get; set; }
    public List<GameObject> friendlyList { get; set; }


    public void Awake()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true) 
        {
            yield return new WaitForSeconds(5.0f);

            enemyList.Add(Instantiate(enemy, new Vector3(1500, Random.Range(0, 720), 0), new Quaternion(0, 0, 0, 1)) as GameObject);
        }

    }
}
