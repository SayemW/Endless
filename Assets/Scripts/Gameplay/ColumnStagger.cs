using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Staggered movement of the columns
/// </summary>
public class ColumnStagger : MonoBehaviour
{
    // RigidBody 2D component
    Rigidbody2D columnRigidBody2D;

    // Get column type 0 - top , 1 - bottom
    int columnType;

    // Timer
    Timer moveTimer;

    // Away duration
    const float AwayDuration = 1;

    // Velocities
    float awayVelocity;
    float towardsVelocity;

    // Original y position
    float yPositionOriginal;

    // Boolean control variables
    bool movingAway = false;
    bool movingClose = false;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody component
        columnRigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        // Set how long we should move away in timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = AwayDuration;


        // Get y position
        yPositionOriginal = gameObject.transform.position.y;
        // Initialize velocity
        if (transform.rotation.z != 0)
        {
            // Top column
            columnType = 0;
            awayVelocity = 2f;
            towardsVelocity = -10f;
        }
        else
        {
            // Bottom column
            columnType = 1;
            awayVelocity = -2f;
            towardsVelocity = 10f;
        }

        // Set initial away velocity
        Vector2 velocity = columnRigidBody2D.velocity;
        velocity.y = awayVelocity;
        columnRigidBody2D.velocity = velocity;
        moveTimer.Run();
        movingAway = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        Vector2 velocity = columnRigidBody2D.velocity;
        if (movingAway && moveTimer.Finished)
        {
            velocity.y = towardsVelocity;
            movingAway = false;
            movingClose = true;
            columnRigidBody2D.velocity = velocity;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (movingClose && collision.CompareTag("Column"))
        {
            Vector2 velocity = columnRigidBody2D.velocity;
            velocity.y = awayVelocity;
            columnRigidBody2D.velocity = velocity;
            movingAway = true;
            movingClose = false;
            moveTimer.Run();
        }        
    }
}
