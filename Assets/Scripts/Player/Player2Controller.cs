using System;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour, AttackTarget, AttackActor {
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------
    public float        startHealth;
    private float       currentHealth;
    public Slider       healthSlider;

    private bool        isAlive;

    // Attack data (Combat)
    private AttackType  attackType;
    public float        meleeRange;
    public float        attackDamages;
    public float        attackColdown;
    private float       attackColdownTimer;
    private bool        isAttackColdownReady = true;

    public GameObject   attackHitPoint; // Where the point impacte happens
    
    // Block data (Combat)
    public bool         isBlocking;
    public float        damageNormalReduce;
    public float        damageBlockValue;
    public float        blockMaxDuration;
    private float       blockCurrentDuration; // Time since block has been activated

    // Block Coldown data (Combat)
    public float        blockColdown;
    private float       blockColdownTimer;
    private bool        isBlockColdownReady = true;


    // ------------------------------------------------------------------------
    // Unity functions
    // ------------------------------------------------------------------------

    // Use this for initialization
    void Start () {
	    this.isAlive                = true;
        this.isBlocking             = false;
        this.currentHealth          = startHealth;
        this.healthSlider.maxValue  = startHealth;
        this.healthSlider.minValue  = 0;
        this.healthSlider.value     = this.currentHealth;
        this.attackType             = new MeleeHandAttackType(this);
    }
	
	// Update is called once per frame
	void Update () {
        // Update attack coldown
        this.attackColdownTimer += Time.deltaTime;
        if (this.attackColdownTimer >= this.attackColdown) {
            this.isAttackColdownReady = true;
        }
        else {
            this.isAttackColdownReady = false;
        }
        //Update block coldown
        this.blockColdownTimer += Time.deltaTime;
        if (this.blockColdownTimer >= this.blockColdown) {
            this.isBlockColdownReady = true;
        }
        else {
            this.isBlockColdownReady = false;
        }

        // TODO Add attack actions according to key
        this.isBlocking = false; //Reset
        // Might be something like if(keyx){ this.attack(); } if(keyx2){ this.block(); }
        if (Input.GetButton("Fire2")) {
            this.block();
        }
        else if (Input.GetButton("Fire1")) {
            this.attack();
        }
    }


    // ------------------------------------------------------------------------
    // General functions
    // ------------------------------------------------------------------------
    public void attack() {
        if (this.isAttackColdownReady) {
            this.attackColdownTimer = 0;
            // TODO find enemy
            Collider2D target = Physics2D.OverlapCircle(this.attackHitPoint.transform.position, this.meleeRange);
            Debug.Log("COLLIDER FOR ATTACK: "+target.ToString());
            //this.attackType.DoAttack(this.player.GetComponent<Player2Controller>());
        }
    }

    public void block() {
        //TODO Add duration management
        if (this.isBlockColdownReady) {
            this.blockColdownTimer = 0;
            this.isBlocking = true;
        }
    }


    // ------------------------------------------------------------------------
    // AttackActor / AttackTarget - Override functions
    // ------------------------------------------------------------------------
    public GameObject GetGameObject() {
        return this.gameObject;
    }

    public float GetDamageReduction() {
        return (this.isBlocking) ? this.damageBlockValue : this.damageNormalReduce;
    }
    
    public float hitByTarget(AttackActor actor, float damages) {
        this.currentHealth = this.currentHealth - damages;
        this.currentHealth = this.currentHealth >= 0 ? this.currentHealth : 0;
        this.healthSlider.value = this.currentHealth;
        if (currentHealth <= 0) {
            this.isAlive = false;
        }
        Debug.Log("[HIT] Enemy hit player (Damage: "+damages+")");
        //TODO Add anims
        return damages;
    }

    public bool IsAlive() {
        return this.isAlive;
    }

    public float GetDamagePower() {
        return this.attackDamages;
    }

    public bool IsAttackColdownReady() {
        return this.isAttackColdownReady;
    }
}
