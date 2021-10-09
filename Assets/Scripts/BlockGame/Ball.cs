using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameClearText;
    [SerializeField] Bar bar;
    [SerializeField] BoxCollider2D rightWall;
    [SerializeField] BoxCollider2D leftWall;
    [SerializeField] BoxCollider2D upWall;
    [SerializeField] BoxCollider2D downWall;
    public float velocity_Ball;
    public Vector2 vec_Ball;
    public Vector2 initVec;
    public Vector2 curVec;
    public Rigidbody2D rigid_Ball;
    public CircleCollider2D coll_Ball;
    public float speed;
    public float slopeOfBar;

    public float hitPointY;
    public float hitPointX;

    public int score;
    public int MaxBlock;

    public bool bossDamage;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        gameOverMenu.SetActive(false);
        rigid_Ball = ball.GetComponent<Rigidbody2D>();
        coll_Ball = ball.GetComponent<CircleCollider2D>();



        score = 0;
        bossDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.SqrMagnitude(rigid_Ball.velocity) < speed)
        {
            rigid_Ball.velocity = curVec.normalized * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)  //  ��򰡿� �ε�����
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (coll_Ball.IsTouching(upWall)) //  ���� ���� �ε���
            {
                curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                rigid_Ball.velocity = curVec;
            }
            if (coll_Ball.IsTouching(rightWall) || coll_Ball.IsTouching(leftWall)) //  �� ���� �ε���
            {
                curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                rigid_Ball.velocity = curVec;
            }
            if (coll_Ball.IsTouching(downWall)) //  �ϴ� ���� �ε���
            {
                gameOverText.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (coll_Ball.IsTouching(bar.coll_Bar)) //  �ٿ� �ε���
        {
            curVec += bar.rigid_bar.velocity;
            Vector2 ballToBar = (collision.collider.transform.position - transform.position).normalized;
            curVec = (new Vector2(-ballToBar.x, -ballToBar.y) * slopeOfBar + new Vector2(curVec.x, -curVec.y)).normalized * speed;

            rigid_Ball.velocity = curVec;
        }
        
        if (collision.collider.CompareTag("Block"))    //  ��Ͽ� �ε���
        {

            foreach (ContactPoint2D contactHIt in collision.contacts)
            {
                Vector2 collPosition = collision.collider.transform.position;
                Vector2 hitPoint = contactHIt.point;
                hitPointY = collPosition.y - hitPoint.y;
                hitPointX = collPosition.x - hitPoint.x;
                if (hitPointY >= 0.2f)  //  ��� �Ʒ��鿡 �ε���
                {
                    curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointY <= -0.2f)  //  ��� ���鿡 �ε���
                {
                    curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointX >= 0.5f)  //  ��� �����ʸ鿡 �ε���
                {
                    curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointX <= -0.5f)  //  ��� ���ʸ鿡 �ε���
                {
                    curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
            }
            score++;
            Destroy(collision.collider.gameObject);

            if (score == MaxBlock)
            {
                bossDamage = true;
            }
        }
        if (collision.collider.CompareTag("Boss"))
        {
            if (bossDamage)
            {
                Destroy(collision.collider.gameObject);
                gameClearText.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                foreach (ContactPoint2D contactHIt in collision.contacts)
                {
                    Vector2 collPosition = collision.collider.transform.position;
                    Vector2 hitPoint = contactHIt.point;
                    hitPointY = collPosition.y - hitPoint.y;
                    hitPointX = collPosition.x - hitPoint.x;
                    if (hitPointY >= 0.7f)  //  ���� �Ʒ��鿡 �ε���
                    {
                        curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                    if (hitPointX >= 0.75f)  //  ���� �����ʸ鿡 �ε���
                    {
                        curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                    if (hitPointX <= -0.75f)  //  ���� ���ʸ鿡 �ε���
                    {
                        curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                }
            }
        }

    }
}
