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
    public bool         isCharging = false; //Public but not for unity inspector purpose
    public float        chargeSpeed;
    public float        chargeFleeSpeed;
    public float        chargeRange;
    public float        chargeMinRange; //Below that, can't charge

    //Walk data
    public float        walkspeed;

    // Attack data (State)
    public bool         isFighting = false;
    public bool         isAtMeleeRange;
    public float        meleeWalkSpeed;
    public int          chanceChargeInMelee; //Will in melee fight, change that he will leave the fight to charge again
    public int          changeChargeOnPlayerFlee; // Chance enemy will charge instead of following player if he flee

    // Attack data (Combat)
    private AttackType  attackType;
    public float        attackMeleeDamage;
    public float        attackChargeDamage;
    private float       currentAttackDamage;
    public float        attackColdown;
    private float       attackColdownTimer;
    private bool        isAttackColdownReady = true;

    // Block data (Combat)
    public float        damageNormalReduce;
    private float       currentDamageReduction;


    // ------------------------------------------------------------------------
    // Functions - Unity
    // ------------------------------------------------------------------------

    // Use this for initialization
    public void Start () {
        this.player         = GameObject.FindGameObjectWithTag("player2");
        this.state          = MoleStateFactory.creaLook4Player();
        this.attackType     = new MeleeHandAttackType(this);
    }
	
	// Update is called once per frame
	public void Update () {
        this.attackColdownTimer += Time.deltaTime;
        if(this.attackColdownTimer >= this.attackColdown) {
            this.isAttackColdownReady = true;
        }
        else {
            this.isAttackColdownReady = false;
        }
        this.state.DoAttack(this, this.player);
	}

    public void FixedUpdate(){
        this.state.DoMove(this, this.player);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == player) {
            this.isAtMeleeRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == player) {
            this.isAtMeleeRange = false;
        }
    }


    // ------------------------------------------------------------------------
    // General functions
    // ------------------------------------------------------------------------
    public void attack() {
        this.attackColdownTimer = 0;
        this.attackType.DoAttack(this.player.GetComponent<Player2Controller>());
    }


    // ------------------------------------------------------------------------
    // Getters - Setters
    // ------------------------------------------------------------------------
    public bool IsAtMeleeRange(){
        return this.isAtMeleeRange;
    }

    /**
     * Check whether is a charge range
     * 
     * return -1 if to far, -2 if to close, 0 if at range
     */
    public int IsAtChargeRange(){
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

    // Set current AI state
    public void SetState(StateBehavior<MoleEnemyController> state){
        this.state.OnExit(this);
        this.state = state;
        this.state.OnEnter(this);
    }

    // It's not an exact strategy pattern: simplified here for the game jam
    public void SetAttackPower(float value) {
        this.currentAttackDamage = value;
    }
    public void SetDamageReduction(float value) {
        this.currentDamageReduction = value;
    }

    
    // ------------------------------------------------------------------------
    // AttackActor / AttackTarget - Override functions
    // ------------------------------------------------------------------------
    public GameObject GetGameObject() {
        return this.gameObject;
    }

    public float GetDamagePower() {
        return this.currentAttackDamage;
    }

    public bool IsAttackColdownReady() {
        return this.isAttackColdownReady;
    }

    public float GetDamageReduction() {
        return this.currentDamageReduction;
    }

    public float hitByTarget(AttackActor actor, float damages) {
        //TODO receive damage
        return 0;
    }

    public bool IsAlive() {
        // TODO
        return true;
    }
}
