using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class contains the behaviour of the player.
/// </summary>

/* 
 * The user taps to push the bird up by giving the bird an impusle force. 
 * The bird is then brought back down by gravity.
 */
public class Player : MonoBehaviour
{
    #region Properties
    // The rigidBody component of the player
    Rigidbody2D playerRigidBody2D;

    // Direction where we should push the player
    Vector2 thrustDirection;

    // Magnitude of thrust
    float magnitude;

    // Health of the player
    int health = 3;

    // Check if player is dead
    bool isDead;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidBody component
        playerRigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        // Set thrust direction (We push the player upwards) &  downward thrust direction
        thrustDirection = new Vector2(0, 1);

        // Set magnitude of upwards thrust
        magnitude = 5;

        // Initialize player health to 3
        health = 3;

        // Initially player is not dead
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user pressed space
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            // Set downward velocity to 0
            playerRigidBody2D.velocity = Vector2.zero;

            // Then we need to give the player flight
            playerRigidBody2D.AddForce(thrustDirection * magnitude, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// If the player collides with any game object then it loses health
    /// The screen visibility must decrease with damage taken (player looses brightness)
    /// Once health goes down to 0 the player dies
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
        {
            isDead = true;
        }
    }
}
