using UnityEngine;
using System.Collections;
using System;

public class MeleeAttack : StateBehavior<MoleEnemyState>{
    private static MeleeAttack singleton;

    private MeleeAttack() { }

    public static MeleeAttack Instance()
    {
        if (MeleeAttack.singleton == null)
        {
            MeleeAttack.singleton = new MeleeAttack();
        }
        return MeleeAttack.singleton;
    }


    // ------------------------------------------------------------------------
    // Override functions - StateBehavior
    // ------------------------------------------------------------------------
    public void OnEnter(MoleEnemyState c)
    {
        throw new NotImplementedException();
    }

    public void OnExit(MoleEnemyState c)
    {
        throw new NotImplementedException();
    }

    public void DoMove(MoleEnemyState c, GameObject o)
    {
        throw new NotImplementedException();
    }

    public void DoAttack(MoleEnemyState c, GameObject o)
    {
        throw new NotImplementedException();
    }
}
