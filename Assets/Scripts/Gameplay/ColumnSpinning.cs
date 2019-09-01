using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the columns spin
/// </summary>
public class ColumnSpinning : MonoBehaviour
{
    const float RotationMagnitude = 120;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, Time.deltaTime * RotationMagnitude);
    }
}
