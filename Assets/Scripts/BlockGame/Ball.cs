using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClearText;
    [SerializeField] GameObject boss;
    [SerializeField] Bar bar;
    [SerializeField] BoxCollider2D rightWall;
    [SerializeField] BoxCollider2D leftWall;
    [SerializeField] BoxCollider2D upWall;
    [SerializeField] BoxCollider2D downWall;
    [SerializeField] Animator animator;


    [SerializeField]
    private AudioClip blockClip;

    public Vector2 vec_Ball;
    public Vector2 initVec;
    public Vector2 curVec;
    public Rigidbody2D rigid_Ball;
    public CircleCollider2D coll_Ball;

    public float velocity_Ball;
    public float speed;
    public float slopeOfBar;
    public float hitPointY;
    public float hitPointX;
    public float t_Damaged;

    public int score;
    public int MaxBlock;

    public bool bossDamage;
    public bool bossDead;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        rigid_Ball = ball.GetComponent<Rigidbody2D>();
        coll_Ball = ball.GetComponent<CircleCollider2D>();



        score = 0;
        bossDamage = false;
        bossDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.SqrMagnitude(rigid_Ball.velocity) < speed)
        {
            rigid_Ball.velocity = curVec.normalized * speed;
        }
        if (bossDead)
        {
            animator.SetInteger("bossDead", 1);
            SaveManager.SavePlayer(new PlayerData(2));
            t_Damaged += Time.deltaTime;
            if (t_Damaged >= 1f)
            {
                Destroy(boss);
                gameClearText.SetActive(true);
                bossDead = false;
                Time.timeScale = 0;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)  //  ???????? ????????
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (coll_Ball.IsTouching(upWall)) //  ???? ???? ??????
            {
                curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                rigid_Ball.velocity = curVec;
            }
            if (coll_Ball.IsTouching(rightWall) || coll_Ball.IsTouching(leftWall)) //  ?? ???? ??????
            {
                curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                rigid_Ball.velocity = curVec;
            }
            if (coll_Ball.IsTouching(downWall)) //  ???? ???? ??????
            {
                gameOverText.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (coll_Ball.IsTouching(bar.coll_Bar)) //  ???? ??????
        {
            curVec += bar.rigid_bar.velocity;
            Vector2 ballToBar = (collision.collider.transform.position - transform.position).normalized;
            curVec = (new Vector2(-ballToBar.x, -ballToBar.y) * slopeOfBar + new Vector2(curVec.x, -curVec.y)).normalized * speed;

            rigid_Ball.velocity = curVec;
        }
        
        if (collision.collider.CompareTag("Block"))    //  ?????? ??????
        {

            foreach (ContactPoint2D contactHIt in collision.contacts)
            {
                Vector2 collPosition = collision.collider.transform.position;
                Vector2 hitPoint = contactHIt.point;
                hitPointY = collPosition.y - hitPoint.y;
                hitPointX = collPosition.x - hitPoint.x;
                if (hitPointY >= 0.2f)  //  ???? ???????? ??????
                {
                    curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointY <= -0.2f)  //  ???? ?????? ??????
                {
                    curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointX >= 0.5f)  //  ???? ?????????? ??????
                {
                    curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
                if (hitPointX <= -0.5f)  //  ???? ???????? ??????
                {
                    curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                    rigid_Ball.velocity = curVec;
                }
            }
            score++;
            Destroy(collision.collider.gameObject);

            var audioSource = new GameObject();
            audioSource.AddComponent<AudioSource>();
            audioSource.GetComponent<AudioSource>().volume = 0.7f;
            var clip = SoundDB.GetAudioClip(SoundEnum.Block);
            audioSource.GetComponent<AudioSource>().PlayOneShot(clip);
            Destroy(audioSource, clip.length);

            if (score == MaxBlock)
            {
                bossDamage = true;
            }
        }
        if (collision.collider.CompareTag("Boss"))
        {
            if (bossDamage)
            {
                bossDead = true;


                
            }
            else
            {
                foreach (ContactPoint2D contactHIt in collision.contacts)
                {
                    Vector2 collPosition = collision.collider.transform.position;
                    Vector2 hitPoint = contactHIt.point;
                    hitPointY = collPosition.y - hitPoint.y;
                    hitPointX = collPosition.x - hitPoint.x;
                    if (hitPointY >= 0.7f)  //  ???? ???????? ??????
                    {
                        curVec = new Vector2(curVec.x, -curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                    if (hitPointX >= 0.75f)  //  ???? ?????????? ??????
                    {
                        curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                    if (hitPointX <= -0.75f)  //  ???? ???????? ??????
                    {
                        curVec = new Vector2(-curVec.x, curVec.y).normalized * speed;
                        rigid_Ball.velocity = curVec;
                    }
                }
            }
        }

    }
}
