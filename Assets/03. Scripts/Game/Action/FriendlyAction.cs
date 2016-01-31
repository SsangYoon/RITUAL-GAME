using UnityEngine;
using System.Collections;

public class FriendlyAction : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private CharState _state;
    public CharState state { get { return _state; } set { _state = value; } }
    private Transform target;

    private float alpha;

    private GameManager gameManager;

    public void Start()
    {
        state = CharState.Idle;
        speed = 1.5f;
        alpha = 1;

        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        gameManager.friendlyList.Add(this.gameObject);

        StartCoroutine(CheckState());
    }
    
    public void Update()
    {
    }

    IEnumerator CheckState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.02f);

            if (GetComponent<Friendly>().hp <= 0)
                state = CharState.Die;

            if(gameManager.gameState == GameState.Night)
            {
                state = CharState.Move;
            }

            switch (state)
            {
                case CharState.Idle:
                    break;
                case CharState.Move:
                    GetComponent<Rigidbody2D>().velocity += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case CharState.Die:
                    if(GetComponent<SpriteRenderer>().color.a > 0)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha-=0.1f);
                    }
                    else
                    {
                        gameManager.friendlyList.Remove(this.gameObject);
                        DestroyObject(gameObject);
                    }
                    break;
                case CharState.Hit:
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0.5f) * 200);
                    state = CharState.Move;
                    if (GetComponent<Enemy>().hp <= 0)
                        state = CharState.Die;
                    break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<EnemyAction>().state != CharState.Die
           && state != CharState.Die)
            {
                col.gameObject.GetComponent<Enemy>().hp -= gameObject.GetComponent<Friendly>().ap;
                col.gameObject.GetComponent<EnemyAction>().state = CharState.Hit;
                gameObject.GetComponent<Friendly>().hp -= col.gameObject.GetComponent<Enemy>().ap;
                state = CharState.Hit;
            }
        }
    }
}
