using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {
    private float speed = 0.5f;
    private CharState state;
    private Transform target;

    private float attackOld;
    private float now;

    public void Awake()
    {
        state = CharState.Idle;

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

            switch (state)
            {
                case CharState.Idle:
                    break;
                case CharState.Move:
                    if ((target.position - transform.position).sqrMagnitude <= 50)
                    {
                        state = CharState.Attack;
                    }
                    break;
                case CharState.Die:
                    gameObject.SetActive(false);
                    break;
                case CharState.Attack:
                    if (now - attackOld >= 0.5)
                    {
                        attackOld = Time.time;
                        
                    }
                    if ((target.position - transform.position).sqrMagnitude > 50)
                    {
                        state = CharState.Move;
                    }
                    break;
            }
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Friendly")
        {
            
        }
    }
}
