using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Mario : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float jumpStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            myRigidbody2D.velocity = Vector2.up * jumpStrength;
        }
    }
}   