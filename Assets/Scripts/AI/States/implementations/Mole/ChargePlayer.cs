using UnityEngine;
using System.Collections;
using System;

/**
 * Charge player
 * 
 */
public class ChargePlayer : StateBehavior<MoleEnemyState>{
    private static ChargePlayer singleton;

    private ChargePlayer() { }

    public static ChargePlayer Instance(){
        if (ChargePlayer.singleton == null){
            ChargePlayer.singleton = new ChargePlayer();
        }
        return ChargePlayer.singleton;
    }


    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void DoAttack(MoleEnemyState c, GameObject o){
        if (c.isAtMeleeRange()){
            c.isCharging = false; // Not charging anymore
            // TODO Do the attack for charge
            // TODO Change to attack state
        }
        // Else, do nothing
    }

    public void DoMove(MoleEnemyState c, GameObject o){

        // If is already chargin, continue
        if (c.isCharging) {
            EnemyMovements.MoveTowardPlayer(c, o, c.chargeSpeed);
        }

        // If is a charge range, chaaaarge!!
        if (c.isAtChargeRange() == 0) {
            c.isCharging = true;
            Debug.Log("[CHARGE]: Start charging!!!! (On chargerange = " + c.isAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, c.chargeSpeed);
        }

        // If is to far, move toward player
        if(c.isAtChargeRange() == -1) {
            Debug.Log("[CHARGE]: To far... (On chargerange = " + c.isAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, c.walkspeed);
        }

        // If is to close, try to go away (And is not already charging)
        if(c.isAtChargeRange() == -2){
            Debug.Log("[CHARGE]: To close... (On chargerange = " + c.isAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, -(c.walkspeed));
        }
    }

    public void OnEnter(MoleEnemyState c){
        Debug.Log("[STATE]: Enter ChargePlayer state");
        c.isCharging = false;
    }

    public void OnExit(MoleEnemyState c){
        Debug.Log("[STATE]: Exit ChargePlayer state");
        c.isCharging = false;
    }
}
