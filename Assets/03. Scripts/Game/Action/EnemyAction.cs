using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {
    private float speed;
    private CharState state;
    private Transform target;

    private float attackOld;
    private float now;

    private GameManager gameManager;

    public void Awake()
    {
        state = CharState.Move;
        speed = 7f;

        gameManager = FindObjectOfType<GameManager>();

        StartCoroutine(CheckState());
    }
    
    public void Update()
    {
        now = Time.time;
    }
    IEnumerator CheckState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            now = Time.time;

            switch (state)
            {
                case CharState.Idle:
                    break;
                case CharState.Move:
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * speed);
                    if(gameManager.friendlyList.Count > 0)
                    {
                        foreach (GameObject obj in gameManager.friendlyList)
                        {
                            if (obj.transform.position.x - transform.position.x <= 50)
                            {
                                target = obj.transform;
                                state = CharState.Fight;
                            }
                        }
                    }
                    break;
                case CharState.Die:
                    DestroyObject(gameObject);
                    break;
                case CharState.Fight:
                    if (now - attackOld <= 0.5)
                    {
                        attackOld = Time.time;
                        state = CharState.Attack;
                    }
                    if ((target.position.x - transform.position.x) > 50)
                    {
                        state = CharState.Move;
                    }
                    break;
                case CharState.Attack:
                    break;
            }
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (state == CharState.Attack)
        {
            if (col.gameObject.name == "Friendly")
            {
                col.gameObject.GetComponent<Friendly>().hp -= gameObject.GetComponent<Enemy>().ap;
            }
        }
    }
}
