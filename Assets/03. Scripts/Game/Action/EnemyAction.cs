using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {
    [SerializeField]
    private float speed;
    public CharState state { get; set; }
    private Transform target;

    private float attackOld;
    private float now;

    private GameManager gameManager;

    public void Start()
    {
        state = CharState.Move;
        speed = 1f;

        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

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
                    GetComponent<Rigidbody2D>().velocity -= new Vector2(speed * Time.deltaTime, 0);
                    break;
                case CharState.Die:
                    DestroyObject(gameObject);
                    break;
                case CharState.Hit:
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0.5f) * 200);
                    state = CharState.Move;
                    break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "friendly")
         {
            col.gameObject.GetComponent<Friendly>().hp -= gameObject.GetComponent<Enemy>().ap;
            col.gameObject.GetComponent<FriendlyAction>().state = CharState.Hit;
            GetComponent<Enemy>().hp -= col.gameObject.GetComponent<Friendly>().ap;
            GetComponent<EnemyAction>().state = CharState.Hit;

        }
    }
}
