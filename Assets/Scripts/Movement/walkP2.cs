using UnityEngine;
using System.Collections;

public class walkP2 : MonoBehaviour {
    public float speed = 0f;
    private Rigidbody2D rigid;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveH = Input.GetAxis("HPlayer2") * speed;
        moveH *= Time.deltaTime;
        rigid.velocity = new Vector2(moveH, rigid.velocity.y);
    }
}
