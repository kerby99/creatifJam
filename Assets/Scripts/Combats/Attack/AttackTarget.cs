
using UnityEngine;

public interface AttackTarget{

    /**
     * Return the target GameObject
     */
    GameObject GetGameObject();

    /**
     * Return amount of damage target can reduce
     */
    float GetDamageReduction();

    /**
     * Process the hit action
     *
     * Return the actual amount of damage received
     */
    float hitByTarget(AttackActor actor, float damages);

    /**
     * Check whether target is alive (Usefull after hit to check if has die)
     */
    bool isAlive();
}