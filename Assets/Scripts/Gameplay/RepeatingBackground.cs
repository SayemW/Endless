using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    // Collider of background object
    BoxCollider2D backgroundBoxCollider2D;

    // Width of background
    float backgroundWidth;

    // How much to shift the background by
    Vector2 backgroundShift;

    // Start is called before the first frame update
    void Start()
    {
        // Get boxCollider
        backgroundBoxCollider2D = gameObject.GetComponent<BoxCollider2D>();

        // Calculate bacground width
        backgroundWidth = backgroundBoxCollider2D.size.x;

        // Calculate shift amount
        backgroundShift = new Vector2(backgroundWidth * 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -backgroundWidth)
        {
            repeatingBackground();
        }
    }

    /// <summary>
    /// This will shift the background once it goes outside the screen
    /// </summary>
    void repeatingBackground()
    {
        // Need to type cast so that it doesn't get confused with Vector3
        transform.position = backgroundShift + (Vector2)transform.position;
    }
}
