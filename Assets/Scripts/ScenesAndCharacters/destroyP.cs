using UnityEngine;
using System.Collections;

public class destroyP : MonoBehaviour {

    public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestroyer");
	}
	
	// Update is called once per frame
	void Update () {
	
        if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}