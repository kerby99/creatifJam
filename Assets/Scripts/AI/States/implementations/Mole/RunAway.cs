using UnityEngine;

public class RunAway : StateBehavior<MoleEnemyController> {
    private static RunAway singleton;

    private RunAway() { }

    public static RunAway Instance(){
        if (RunAway.singleton == null) {
            RunAway.singleton = new RunAway();
        }
        return RunAway.singleton;
    }


    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void DoAttack(MoleEnemyController c, GameObject o){
        // TODO
    }

    public void DoMove(MoleEnemyController c, GameObject o){
        // TODO
    }

    public void OnEnter(MoleEnemyController c){
        // TODO
    }

    public void OnExit(MoleEnemyController c){
        // TODO
    }
}