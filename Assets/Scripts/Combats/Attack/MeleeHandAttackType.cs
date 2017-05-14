

using UnityEngine;
/**
* Attack type using hands in melee
*/
public class MeleeHandAttackType : AttackType {
    private AttackActor attackActor;

    public MeleeHandAttackType(AttackActor o) {
        this.attackActor = o;
    }

    public float DoAttack(AttackTarget target) {
        float damage = this.attackActor.GetDamagePower() - target.GetDamageReduction();
        damage = (damage <= 0) ? 0 : damage; // In case of
        return target.hitByTarget(this.attackActor, damage);
    }
}