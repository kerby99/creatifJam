
public interface AttackType {

    /**
     * Attack a target
     * 
     * return the actual amount of damage done
     */
    float DoAttack(AttackTarget target);
}