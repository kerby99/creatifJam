using UnityEngine;
using System.Collections;

public class WalkP1 : MonoBehaviour
{

    public float speed = 0f;
    public float jump = 0f;
    private bool isFalling = false;
    bool allowJump = true;
    public float timeLimit = 1;
    public float timePassed = 0;
    Rigidbody2D rigid;
    HealthBarP1 player1Health;
    GameObject player1;
    // Use this for initialization

    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("player1");
        player1Health = GetComponent<HealthBarP1>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving the player
        float moveH = Input.GetAxis("HPlayer1") * speed;
        moveH *= Time.deltaTime;

        rigid.velocity = new Vector2(moveH, rigid.velocity.y);
        if (Input.GetButton("Jplayer1"))
        {
            if (timePassed < timeLimit && !isFalling && allowJump)
            {
                timePassed += Time.deltaTime;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
            else
            {
                allowJump = false;
                isFalling = true;
            }
        }
        else if (timeLimit < 0)
        {
            isFalling = true;
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        timePassed = 0;
        if (Input.GetButton("Jplayer1") && isFalling)
        {
            allowJump = false;
        }
        else
        {
            allowJump = true;
        }
        isFalling = false;
        rigid.velocity = new Vector2(rigid.velocity.x, 0);

        if (c.gameObject.tag == "pic")
        {
            Debug.LogWarning(player1Health);
            
        }else if(c.gameObject.tag == "switch")
        {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
            foreach (GameObject go in doors)
            {
                go.SetActive(false);
            }
            //GameObject door = GameObject.Find("Door");
            //door.SetActive(false);
        }
    }
    void OnCollisionStay2D(Collision2D c)
    {
        timePassed = 0;
        if (Input.GetButton("Jplayer1") && isFalling)
        {
            allowJump = false;
        }
        else
        {
            allowJump = true;
        }
        isFalling = false;
        rigid.velocity = new Vector2(rigid.velocity.x, 0);

    }
    void OnCollisionExit2D(Collision2D c)
    {
        isFalling = true;
    }
}