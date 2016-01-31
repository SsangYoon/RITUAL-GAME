using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {
    [SerializeField]
    private float speed;
    public CharState state { get; set; }
    private Transform target;

    private float alpha;

    private GameManager gameManager;

    public void Start()
    {
        state = CharState.Move;
        speed = 10f;

        alpha = 1;

        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        StartCoroutine(CheckState());
    }
    
    public void Update()
    {
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
                    GetComponent<Rigidbody2D>().velocity -= new Vector2(speed * Time.deltaTime, 0);
                    break;
                case CharState.Die:
                    if (GetComponent<SpriteRenderer>().color.a > 0)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha -= 0.1f);
                    }
                    else
                    {
                        gameManager.enemyList.Remove(this.gameObject);
                        DestroyObject(gameObject);
                    }
                    break;
                case CharState.Hit:
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0.5f) * 200);
                    state = CharState.Move;
                    if (GetComponent<Enemy>().hp <= 0)
                        state = CharState.Die;
                    break;
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        //if (col.gameObject.tag == "Friendly")
        //{
        //    if (col.gameObject.GetComponent<FriendlyAction>().state != CharState.Die
        //      && state != CharState.Die)
        //    {
        //        col.gameObject.GetComponent<Friendly>().hp -= gameObject.GetComponent<Enemy>().ap;
        //        col.gameObject.GetComponent<FriendlyAction>().state = CharState.Hit;
        //        GetComponent<Enemy>().hp -= col.gameObject.GetComponent<Friendly>().ap;
        //        GetComponent<EnemyAction>().state = CharState.Hit;

        //    }
        //}
           
    }
}
