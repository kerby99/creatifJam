using UnityEngine;
using System.Collections;


// DEV NOTE: this is note the best way to deal with that but, time is running low and I'll stick with that
public abstract class EnemyMovements {

    public static void MoveTowardPlayer(MoleEnemyState enemy, GameObject player, float speed){
        Vector2 dir = player.transform.position - enemy.transform.position;
        dir = dir.normalized;
        Vector2 velocity = dir * speed;
        enemy.gameObject.GetComponent<Rigidbody>().AddForce(velocity);
    }
}
