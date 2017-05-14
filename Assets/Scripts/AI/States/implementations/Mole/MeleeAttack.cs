using UnityEngine;

public class MeleeAttack : StateBehavior<MoleEnemyController> {
    private static MeleeAttack singleton;

    private MeleeAttack() { }

    public static MeleeAttack Instance(){
        if (MeleeAttack.singleton == null) {
            MeleeAttack.singleton = new MeleeAttack();
        }
        return MeleeAttack.singleton;
    }


    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void OnEnter(MoleEnemyController c){
        Debug.Log("[STATE]: Enter Look4player state");
        c.SetAttackPower(c.attackMeleeDamage);
        c.isFighting = true; // Start fighting
    }

    public void OnExit(MoleEnemyController c){
        Debug.Log("[STATE]: Exit Look4player state");
        c.isFighting = false;
    }

    public void DoMove(MoleEnemyController c, GameObject o){
        // Is in range, so he fight!
        if (c.IsAtMeleeRange() == true){
            // Chance that he flee the fight to charge again!
            if (RandomHelper.tossRandom(c.chanceChargeInMelee * Time.deltaTime)){
                //Debug.Log("[MELEE] Flee melee to charge again!!!! Yeeaaaah!");
                c.SetState(MoleStateFactory.creaChargePlayer());
            }
        }

        // Try to stay on range, if not, go on range
        // There is a little chance he try to charge again instead of following
        else if (c.IsAtMeleeRange() == false){
            if (RandomHelper.tossRandom(c.changeChargeOnPlayerFlee * Time.deltaTime)) {
                //Debug.Log("[MELEE] Player Flee and enemy try to charge again!!");
                c.SetState(MoleStateFactory.creaChargePlayer());
            }
            else {
                //Debug.Log("[MELEE] Try to fight but enemy to far away");
                EnemyMovements.MoveTowardPlayer(c, o, c.meleeWalkSpeed);
            }
        }
    }

    public void DoAttack(MoleEnemyController c, GameObject o){
        if (c.IsAtMeleeRange()) {
            c.isFighting = true;
            // Check if can attack (Because can be on coldown for example)
            if(c.IsAttackColdownReady() == true) {
                c.attack();
            }
        }
        else{
            c.isFighting = false;
        }
    }
}