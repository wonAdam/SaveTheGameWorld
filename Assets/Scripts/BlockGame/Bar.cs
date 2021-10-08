using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject wall;
    public Rigidbody2D rigid;
    public float velocity_bar;
    public BoxCollider2D coll_Bar;
    public BoxCollider2D coll_Wall;
    public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        rigid = bar.GetComponent<Rigidbody2D>();
        coll_Bar = bar.GetComponent<BoxCollider2D>();
        coll_Wall = wall.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.right * velocity_bar;
    }

}
