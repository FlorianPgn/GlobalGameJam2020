using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    private float MaxSpeed = 10f;
    [SerializeField, Range(0f, 100f)]
    private float MaxAcceleration = 10f;
    [SerializeField, Range(0f, 10f)]
    private float TurnSpeed = 4f;

    private Vector3 _velocity, _desiredVelocity;
    private Rigidbody body;

    void Awake () {
		body = GetComponent<Rigidbody>();
	}
    
    void Update () {
        Vector2 playerInput;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f) * MaxSpeed;
       if(Math.Abs(playerInput.x) > float.Epsilon || Math.Abs(playerInput.y) > float.Epsilon)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(playerInput.x, 0, playerInput.y)), 0.15f);
        _desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y);
        
    }

    private void FixedUpdate()
    {
        UpdateState();
        float maxSpeedChange = MaxAcceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, maxSpeedChange);
        _velocity.z = Mathf.MoveTowards(_velocity.z, _desiredVelocity.z, maxSpeedChange);
        _velocity = _desiredVelocity;

        body.velocity = _velocity;
    }

    public void Move(float h, float v)
    {
        Vector2 playerInput = new Vector2(h, v);
        playerInput = Vector2.ClampMagnitude(playerInput, 1f) * MaxSpeed;
        if(Math.Abs(playerInput.x) > float.Epsilon || Math.Abs(playerInput.y) > float.Epsilon)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(playerInput.x, 0, playerInput.y)), 0.15f);
        _desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y);
    }
    
    void UpdateState()
    {
        _velocity = body.velocity;
    }

    void OnCollisionStay (Collision collision) {
        EvaluateCollision(collision);
    }
    
    void EvaluateCollision (Collision collision) {
        for (int i = 0; i < collision.contactCount; i++) {
            Vector3 normal = collision.GetContact(i).normal;
        }
    }
}
