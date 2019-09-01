using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scrolls the background to make it look like the player is moving
/// </summary>
public class ScrollingBehavior : MonoBehaviour
{
    // Rigidbody component of the background
    Rigidbody2D backgroundRigidBody2D;

    // Moving velocity for the bacground
    const float XVelocity = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        backgroundRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        backgroundRigidBody2D.velocity = new Vector2(XVelocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
