using UnityEngine;
using System.Collections;

public class plateform : MonoBehaviour {


    public GameObject[] thePlatform;
    public Transform generationPoint;
    public float distanceBet;
    private int indrand;

    private float platformWidth;
    // Use this for initialization
    void Start () {

        platformWidth = thePlatform[0].GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBet, transform.position.y, transform.position.z);
            indrand = Random.Range(0, 7);
            Debug.LogWarning(indrand);
            Instantiate(thePlatform[indrand], transform.position, transform.rotation);
        }
	}
}
