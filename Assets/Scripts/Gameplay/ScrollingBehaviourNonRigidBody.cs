﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBehaviourNonRigidBody : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        position.x -= (2.5f * Time.deltaTime);
        gameObject.transform.position = position;
    }
}
