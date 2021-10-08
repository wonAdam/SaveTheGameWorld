using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
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
    // Start is called before the first frame update
    void Start()
    {
        rigid_Ball = ball.GetComponent<Rigidbody2D>();
        coll_Ball = ball.GetComponent<CircleCollider2D>();
        vec_Ball = Vector2.down;
        initVec = (vec_Ball * velocity_Ball).normalized * speed;
        rigid_Ball.velocity = initVec;
        curVec = initVec;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)  //  ¾îµò°¡¿¡ ºÎµúÈú½Ã
    {
        if (coll_Ball.IsTouching(bar.coll_Bar)) //  ¹Ù¿¡ ºÎµúÈû
        {
            curVec += bar.rigid_bar.velocity;
            curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
            rigid_Ball.velocity = curVec;
        }
        if (coll_Ball.IsTouching(upWall)) //  À§ÂÊ º®¿¡ ºÎµúÈû
        {
            curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
            rigid_Ball.velocity = curVec;
        }
        if (coll_Ball.IsTouching(rightWall) || coll_Ball.IsTouching(leftWall)) //  ¿· º®¿¡ ºÎµúÈû
        {
            curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
            rigid_Ball.velocity = curVec;
        }

    }
}
