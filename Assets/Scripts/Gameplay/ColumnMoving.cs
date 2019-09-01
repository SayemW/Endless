using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gives the columns up and down motion
/// </summary>
public class ColumnMoving : MonoBehaviour
{
    // RigidBody component of the columns
    Rigidbody2D columnRigidBody2D;

    // Vertical moving velocity
    const float VelocityY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        columnRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        
        // Set initial moving velocity
        if (gameObject.transform.position.y > 0)
        {
            setVelocity(false);
        }
        else
        {
            setVelocity(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        if (position.y >= 2)
        {
            setVelocity(false);
        }
        else if (position.y <= -2)
        {
            setVelocity(true);
        }
    }

    void setVelocity(bool up)
    {
        Vector2 velocity = columnRigidBody2D.velocity;
        if (up)
        {
            velocity.y = VelocityY;
        }
        else
        {
            velocity.y = -VelocityY;
        }
        columnRigidBody2D.velocity = velocity;
    }
}
