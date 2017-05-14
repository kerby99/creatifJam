using UnityEngine;

/**
 * Define states for characters
 */
public interface StateBehavior<T>{

    /**
     * Called when enter this state
     *
     */
    void OnEnter(T c);

    /**
     * Called when exit this state
     */
    void OnExit(T c);

    /**
     * Apply a move behavior according to this state
     *
     * param c actor of the behavior
     * param o movement probable target
     */
    void DoMove(T c, GameObject o);

    /**
     * Apply a attack behavior according to this state
     *
     * param c actor of the behavior
     * param o poor attacked dude
     */
    void DoAttack(T c, GameObject o);
}
