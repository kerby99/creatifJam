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
        // Move toward player
        EnemyMovements.MoveTowardPlayer(c, o, c.walkspeed);

        //If reached chargerange
        if (c.isAtChargeRange() == 0){
            this.OnExit(c);
            c.SetState(MoleStateFactory.creaChargePlayer());
        }

        // If is not at chargerange but at meleerange
        else if (c.isAtMeleeRange()){
            this.OnExit(c);
            // TODO Switch to attack state
        }
    }

    public void OnEnter(MoleEnemyState c){
        Debug.Log("[STATE]: Enter Look4player state");
        // Do Nothing
    }

    public void OnExit(MoleEnemyState c){
        Debug.Log("[STATE]: Exit Look4player state");
        // Do Nothing
    }
}
