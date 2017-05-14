using System;
using UnityEngine;

public class Player2Controller : MonoBehaviour, AttackTarget {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }


    // ------------------------------------------------------------------------
    // AttackActor / AttackTarget - Override functions
    // ------------------------------------------------------------------------
    public float GetDamageReduction() {
        //TODO
        return 0;
    }

    public GameObject GetGameObject() {
        return this.gameObject;
    }

    public float hitByTarget(AttackActor actor, float damages) {
        //TODO
        Debug.Log("HIIIIIIIIIIIIT ("+damages+")");
        return 0;
    }

    public bool isAlive() {
        //TODO
        return true;
    }
}
