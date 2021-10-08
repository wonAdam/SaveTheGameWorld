using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject wall_Right;
    [SerializeField] GameObject wall_Left;
    public Rigidbody2D rigid_bar;
    public float velocity_bar;
    public float vec_bar;
    public BoxCollider2D coll_Bar;
    public BoxCollider2D coll_Wall;
    public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        rigid_bar = bar.GetComponent<Rigidbody2D>();
        coll_Bar = bar.GetComponent<BoxCollider2D>();
        coll_Wall = wall_Right.GetComponent<BoxCollider2D>();
        coll_Wall = wall_Right.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid_bar.velocity = Vector2.right * vec_bar * velocity_bar;    //  πŸ ¿Ãµø
    }
}
