﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    private float MaxSpeed = 10f;
   
    private Vector3 _velocity, _desiredVelocity;
    private Rigidbody body;
    public Transform PlayerModel;

    public Animator PlayerController;
    
    void Awake () {
		body = GetComponent<Rigidbody>();
        //PlayerController = GetComponent<Animator>();
        
	}

    private void FixedUpdate()
    {
        _velocity = body.velocity;
        _velocity = _desiredVelocity;

        body.velocity = _velocity;
    }

    public void Move(float h, float v)
    {
        Vector2 playerInput = new Vector2(h, v);
        
        playerInput = Vector2.ClampMagnitude(playerInput, 1f) * MaxSpeed;
        if (playerInput.magnitude > float.Epsilon)
        {
            PlayerModel.rotation = Quaternion.Slerp(PlayerModel.rotation, Quaternion.LookRotation(new Vector3(playerInput.x, 0, playerInput.y)), 0.15f);
        }
        PlayerController.SetBool("Move", playerInput.magnitude > float.Epsilon);
        _desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y);
    }
}
