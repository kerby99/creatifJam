
public class NoAttackType : AttackType {
    public float DoAttack(AttackTarget target) {
        // Can't attack
        return 0;
    }
}
