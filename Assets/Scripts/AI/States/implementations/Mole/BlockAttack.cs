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
        // TODO
    }

    public void DoMove(MoleEnemyController c, GameObject o) {
        // TODO
    }

    public void OnEnter(MoleEnemyController c) {
        // TODO
    }

    public void OnExit(MoleEnemyController c) {
        // TODO
    }
}