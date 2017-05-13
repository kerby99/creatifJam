using UnityEngine;

public class MoleEnemyState : MonoBehaviour {
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------

    // General use
    private GameObject player; //The naughty enemy! (Probably you if you play the game)
    protected StateBehavior<MoleEnemyState> state;

    // Charge data
    public float chargeRange;
    public float chargeMinRange; //Below that, can't charge
    public float chargeCooldown; //Time between 2 charges
    private float chargeLastTimeUse;

    //Walk data
    public float walkspeed;

    
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

    public void SetState(StateBehavior<MoleEnemyState> state){
        this.state = state;
    }
}
