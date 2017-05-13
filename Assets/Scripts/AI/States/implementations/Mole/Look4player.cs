using UnityEngine;
using System.Collections;
using System;

public class Look4player : StateBehavior<MoleEnemyState>{
    private static Look4player singleton;

    private Look4player() { }

    public static Look4player Instance(){
        if(Look4player.singleton == null) {
            Look4player.singleton = new Look4player();
        }
        return Look4player.singleton;
    }

    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void DoAttack(MoleEnemyState c, GameObject o){
        //Cannot attack
    }

    public void DoMove(MoleEnemyState c, GameObject o){
        Vector2 dir = o.transform.position - c.transform.position;
        dir = dir.normalized;
        Vector2 velocity = dir * Time.deltaTime * c.walkspeed;
        c.gameObject.GetComponent<Rigidbody>().AddForce(velocity);
    }

    public void OnEnter(MoleEnemyState c){
        // Do Nothing
    }

    public void OnExit(MoleEnemyState c){
        // Do Nothing
    }
}
