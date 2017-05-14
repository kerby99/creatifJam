using System;
using UnityEngine;


/**
 * General controller for a Mole Enemy
 */
public class MoleEnemyController : MonoBehaviour, AttackActor, AttackTarget {
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------

    // General data
    private GameObject player; //The naughty enemy! (Probably you if you play the game)
    protected StateBehavior<MoleEnemyController> state;

    // Charge data
    public float        chargeSpeed;
    public float        chargeFleeSpeed;
    public float        chargeRange;
    public float        chargeMinRange; //Below that, can't charge
    public bool         isCharging = false; //Public but not for unity inspector purpose

    //Walk data
    public float        walkspeed;

    // Attack data (State)
    public float        meleeWalkSpeed;
    public float        meleeRange;
    public bool         isFighting = false;
    public int          chanceChargeInMelee; //Will in melee fight, change that he will leave the fight to charge again
    public int          changeChargeOnPlayerFlee; // Chance enemy will charge instead of following player if he flee

    // Attack data (Combat)
    private AttackType  attackType;
    public float        attackDamage;

    // Block data (Combat)
    public float        damageNormalReduce;


    // ------------------------------------------------------------------------
    // Functions - Unity
    // ------------------------------------------------------------------------

    // Use this for initialization
    public void Start () {
        this.player         = GameObject.FindGameObjectWithTag("PlayerFat");
        this.state          = MoleStateFactory.creaLook4Player();
        this.attackType     = new MeleeHandAttackType(this);
    }
	
	// Update is called once per frame
	public void Update () {
        this.state.DoAttack(this, this.player);
	}

    public void FixedUpdate(){
        this.state.DoMove(this, this.player);
    }
    

    // ------------------------------------------------------------------------
    // Getters - Setters
    // ------------------------------------------------------------------------
    public bool isAtMeleeRange(){
        Vector2 distvector = this.player.transform.position - this.transform.position;
        return distvector.magnitude <= this.meleeRange;
    }

    /**
     * Check whether is a charge range
     * 
     * return -1 if to far, -2 if to close, 0 if at range
     */
    public int isAtChargeRange(){
        Vector2 distvect = this.player.transform.position - this.transform.position;
        if(distvect.magnitude > chargeRange){
            return -1;
        }
        else if (distvect.magnitude <= chargeMinRange)
        {
            return -2;
        }
        return 0;
    }

    public void SetState(StateBehavior<MoleEnemyController> state){
        this.state = state;
        this.state.OnEnter(this);
    }

    
    // ------------------------------------------------------------------------
    // AttackActor / AttackTarget - Override functions
    // ------------------------------------------------------------------------
    public GameObject GetGameObject() {
        return this.gameObject;
    }

    public float GetDamagePower() {
        return this.attackDamage;
    }

    public bool CanAttack() {
        //TODO Not used (Design issue)
        return false;
    }

    public float GetDamageReduction() {
        return this.damageNormalReduce;
    }

    public float hit(AttackActor actor, float damages) {
        //TODO
        return 0;
    }
}
