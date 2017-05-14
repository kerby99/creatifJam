using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarP1 : MonoBehaviour {

    public int startingHealth;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.


    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    WalkP1 p1;
    walkP2 p2;
    //PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        p1 = GetComponent<WalkP1>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        isDead = false;
    }


    void Update()
    {
        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            gameOver();
        }
    }

    void gameOver()
    {
        isDead = true;
        SceneManager.LoadScene("GameOver");
        //p1.enabled = false;
        //p2.enabled = false;
    }
}
