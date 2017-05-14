using UnityEngine;
using System.Collections;

public static class RandomHelper {

    /**
     * Toss a virtual 100 face die and return tru if win
     * Win if value is inf or equals to given chance
     */
    public static bool tossRandom(float percentChance){
        float die = Random.Range(1, 100);
        return die <= percentChance;
    }
}
