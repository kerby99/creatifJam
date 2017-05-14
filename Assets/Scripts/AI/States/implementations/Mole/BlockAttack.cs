using UnityEngine;

public class BlockAttack : StateBehavior<MoleEnemyController> {
    private static BlockAttack singleton;

    private BlockAttack() { }

    public static BlockAttack Instance() {
        if (BlockAttack.singleton == null) {
            BlockAttack.singleton = new BlockAttack();
        }
        return BlockAttack.singleton;
    }


    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void DoAttack(MoleEnemyController c, GameObject o) {
        // No attack
    }

    public void DoMove(MoleEnemyController c, GameObject o) {
        // No movement
    }

    public void OnEnter(MoleEnemyController c) {
        Debug.Log("[STATE]: Enter Block state");
        c.isBlocking = true;
        c.Invoke("StopBlocking", c.blockDuration); //Exit block state in x seconds
    }

    public void OnExit(MoleEnemyController c) {
        Debug.Log("[STATE]: Exit Block state");
        c.isBlocking = false;
    }
}