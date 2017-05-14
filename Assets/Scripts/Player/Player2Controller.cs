using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour, AttackTarget {
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------
    public float    startHealth;
    private float   currentHealth;
    public Slider   healthSlider;

    private bool    isAlive;


    // ------------------------------------------------------------------------
    // Unity functions
    // ------------------------------------------------------------------------

    // Use this for initialization
    void Start () {
	    this.isAlive = true;
        this.currentHealth = startHealth;
        this.healthSlider.maxValue = startHealth;
        this.healthSlider.minValue = 0;
        this.healthSlider.value = this.currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        // TODO
    }


    // ------------------------------------------------------------------------
    // AttackActor / AttackTarget - Override functions
    // ------------------------------------------------------------------------
    public GameObject GetGameObject() {
        return this.gameObject;
    }

    public float GetDamageReduction() {
        return 0; // No reduction for you player.. Sorry :p
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
}
