using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float baseSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] CrashDetector crashDetector;

    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;

   
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); //FindObjectOfType se usa cuando sabemos que solo hay un objeto de dicho tipo
    }

    
    void Update()
    {
        if (!crashDetector.hasCrashed)
        {
            RotatePlayer();
            RespondToBoost();
        }

    }


    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !crashDetector.hasCrashed)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (!crashDetector.hasCrashed)
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
}
