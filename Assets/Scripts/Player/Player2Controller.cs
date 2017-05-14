using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool         isFighting;
    public float        meleeRange;
    public float        attackDamages;
    public float        attackColdown;
    private float       attackColdownTimer;
    private bool        isAttackColdownReady = true;

    public GameObject   attackHitPoint; // Where the point impacte happens
    
    // Block data (Combat)
    public bool         isBlocking; // Block can be used anytime
    public float        damageNormalReduce;
    public float        damageBlockValue;


    // ------------------------------------------------------------------------
    // Unity functions
    // ------------------------------------------------------------------------

    // Use this for initialization
    void Start () {
	    this.isAlive                = true;
        this.isBlocking             = false;
        this.isFighting             = false;
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
        
        // Attack Actions
        this.isBlocking = false; //Reset values
        this.isFighting = false;
        //Block is checked before attack so that he can't attack and block at same time
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
            this.isFighting = true;
            this.attackColdownTimer = 0;
            Collider2D target = Physics2D.OverlapCircle(this.attackHitPoint.transform.position, this.meleeRange);
            AttackTarget t = target.GetComponent<AttackTarget>();
            this.attackType.DoAttack(t);
        }
    }

    public void block() {
        this.isBlocking = true;
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
            gameOver();
        }
        Debug.Log("[HIT] Enemy hit player (Damage: "+damages+")");
        //TODO Add anims
        return damages;
    }

    void gameOver()
    {
        
        SceneManager.LoadScene("GameOver");
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
