using UnityEngine;
using System.Collections;


// DEV NOTE: this is note the best way to deal with that but, time is running low and I'll stick with that
public abstract class EnemyMovements {

    public static void MoveTowardPlayer(MoleEnemyController enemy, GameObject player, float speed){
        float dir = player.transform.position.x - enemy.transform.position.x;
        dir = (dir>0)? 1 : -1; //Transform in just a sign
        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(dir * speed, 0));
    }
}
