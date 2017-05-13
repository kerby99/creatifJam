using UnityEngine;
using System.Collections;

public abstract class MoleStateFactory {

    public static Look4player creaLook4Player(){
        return Look4player.Instance();
    }
}
