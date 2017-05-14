using UnityEngine;

public class Look4player : StateBehavior<MoleEnemyController> {
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
    public void DoAttack(MoleEnemyController c, GameObject o){
        //Cannot attack
    }

    public void DoMove(MoleEnemyController c, GameObject o){
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

    public void OnEnter(MoleEnemyController c){
        Debug.Log("[STATE]: Enter Look4player state");
        // Do Nothing
    }

    public void OnExit(MoleEnemyController c){
        Debug.Log("[STATE]: Exit Look4player state");
        // Do Nothing
    }
}