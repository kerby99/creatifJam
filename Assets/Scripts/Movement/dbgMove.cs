using UnityEngine;
using System.Collections;

public class dbgMove : MonoBehaviour {
    private Rigidbody rg;
    public float speed;

	// Use this for initialization
	void Start () {
        this.rg = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        this.handleMovement(x, y, 0);
    }

    private void handleMovement(float x, float y, float z){
        x = x * this.speed;
        y = y * this.speed;
        z = z * this.speed;
        Vector3 newv = new Vector3(x, y, z);
        this.rg.velocity = newv;
    }
}
