using UnityEngine;
using System.Collections.Generic;

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
        // Can't attack
    }

    public void DoMove(MoleEnemyController c, GameObject o) {
        // negative value because flee the player
        EnemyMovements.MoveTowardPlayer(c, o, -(c.runAwaySpeed));
    }

    public void OnEnter(MoleEnemyController c){
        c.isRunningAway = true;
        c.CallForHelp();
        c.Invoke("StopRunningAway", c.runAwayDuration); //To exit this state after x seconds
    }

    public void OnExit(MoleEnemyController c){
        c.isRunningAway = false;
    }
}