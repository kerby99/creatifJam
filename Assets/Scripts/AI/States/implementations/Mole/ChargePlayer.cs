using UnityEngine;

/**
 * Charge behavior
 * Enemy try to charge player
 * If is to far, walk toward player
 * If is to close, go away to be on charge range
 * If is on charge range.. well.. Sorry for you player
 */
public class ChargePlayer : StateBehavior<MoleEnemyController> {
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
    public void DoAttack(MoleEnemyController c, GameObject o){
        // Is is charging and reached the melee range, give a freaking motherf*****g big hit in your face
        if (c.IsAtMeleeRange() && c.isCharging) {
            //Debug.Log("[CHARGE]: charge just reached it's destination: poor player...");
            c.attack(); // Take that ugly player!
            c.SetState(MoleStateFactory.creaMeleeAttack());
        }
        // Else, is in range but must load it's charge (Move do the job)
    }

    public void DoMove(MoleEnemyController c, GameObject o){
        // If is already chargin, continue
        if (c.isCharging) {
            EnemyMovements.MoveTowardPlayer(c, o, c.chargeSpeed);
        }

        // If is a charge range, chaaaarge!!
        if (c.IsAtChargeRange() == 0) {
            c.isCharging = true;
            //Debug.Log("[CHARGE]: Start charging!!!! (On chargerange = " + c.IsAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, c.chargeSpeed);
        }

        // If is to far, move toward player
        if(c.IsAtChargeRange() == -1) {
            //Debug.Log("[CHARGE]: To far... (On chargerange = " + c.IsAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, c.walkspeed);
        }

        // If is to close, try to go away (And is not already charging)
        if(c.IsAtChargeRange() == -2){
            //Debug.Log("[CHARGE]: To close... (On chargerange = " + c.IsAtChargeRange() + ")");
            EnemyMovements.MoveTowardPlayer(c, o, -(c.chargeFleeSpeed));
        }
    }

    public void OnEnter(MoleEnemyController c){
        Debug.Log("[STATE]: Enter ChargePlayer state");
        c.SetAttackPower(c.attackChargeDamage);
        c.isCharging = false;
    }

    public void OnExit(MoleEnemyController c){
        Debug.Log("[STATE]: Exit ChargePlayer state");
        c.isCharging = false;
    }
}
