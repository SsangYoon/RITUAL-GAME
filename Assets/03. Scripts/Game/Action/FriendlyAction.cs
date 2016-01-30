using UnityEngine;
using System.Collections;

public class FriendlyAction : MonoBehaviour {
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
        gameManager.friendlyList.Add(this.gameObject);

        StartCoroutine(CheckState());
    }
    
    public void Update()
    {
        now = Time.time;
    }

    IEnumerator CheckState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.02f);

            if (GetComponent<Friendly>().hp <= 0)
                state = CharState.Die;

            switch (state)
            {
                case CharState.Idle:
                    Debug.Log("Im Idle");
                    break;
                case CharState.Move:
                    Debug.Log("Im Move");
                    GetComponent<Rigidbody2D>().velocity += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case CharState.Die:
                    Debug.Log("Im Die");
                    DestroyObject(gameObject);
                    break;
                case CharState.Hit:
                    Debug.Log("Im Hit");
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0.5f) * 300);
                    state = CharState.Move;
                    break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
         if (col.gameObject.name == "enemy")
         {
            col.gameObject.GetComponent<Enemy>().hp -= gameObject.GetComponent<Friendly>().ap;
            col.gameObject.GetComponent<EnemyAction>().state = CharState.Hit;
            gameObject.GetComponent<Friendly>().hp -= col.gameObject.GetComponent<Enemy>().ap;
            gameObject.GetComponent<FriendlyAction>().state = CharState.Hit;
         }
    }
}
