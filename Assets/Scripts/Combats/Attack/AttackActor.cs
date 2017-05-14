using UnityEngine;

/**
 * Define interface for someone that can attack
 */
public interface AttackActor {

    /**
     * Return the actor GameObject
     */
    GameObject GetGameObject();

    /**
     * Return damage actor make at each attack
     */
    float GetDamagePower();

    /**
     * Check whether actor can attack now 
     * (Or is busy doing other things, like coding for a game jam)
     */
    bool CanAttack();
}