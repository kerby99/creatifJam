using UnityEngine;

public class MoleEnemyState : MonoBehaviour {
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------

    // General data
    private GameObject player; //The naughty enemy! (Probably you if you play the game)
    protected StateBehavior<MoleEnemyState> state;

    // Charge data
    public float        chargeRange;
    public float        chargeSpeed;
    public float        chargeMinRange; //Below that, can't charge
    public float        chargeCooldown; //Time between 2 charges
    private float       chargeLastTimeUse;
    public bool         isCharging; //Public but not for unity inspector purpose

    //Walk data
    public float        walkspeed;

    // Attack data
    public float        meleeRange;
    

    // ------------------------------------------------------------------------
    // Functions - Unity
    // ------------------------------------------------------------------------

    // Use this for initialization
    public void Start () {
        this.player = GameObject.FindGameObjectWithTag("PlayerFat");
        this.state = MoleStateFactory.creaLook4Player();
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
        return this.meleeRange >= distvector.magnitude;
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

    public void SetState(StateBehavior<MoleEnemyState> state){
        this.state = state;
        this.state.OnEnter(this);
    }
}
