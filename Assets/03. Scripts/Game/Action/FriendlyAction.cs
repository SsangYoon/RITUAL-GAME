using UnityEngine;
using System.Collections;

public class FriendlyAction : MonoBehaviour {
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
           
        gameManager = GetComponent<GameManager>();

        StartCoroutine(CheckState());
    }
 
    IEnumerator CheckState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.02f);
            now = Time.time;

            if (GetComponent<Friendly>().hp <= 0)
                state = CharState.Die;

            switch (state)
            {
                case CharState.Idle:
                    break;
                case CharState.Move:
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * speed);
                    if(gameManager.enemyList.Count > 0)
                    {
                        foreach (GameObject obj in gameManager.enemyList)
                        {
                            if (obj.transform.position.x - transform.position.x <= 50)
                            {
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
            if (col.gameObject.name == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().hp -= gameObject.GetComponent<Friendly>().ap;
            }
        }
    }
}
