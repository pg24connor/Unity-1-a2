using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed = 20f;

    [SerializeField]
    private float _acceleration = 10f;

    [SerializeField]
    private float _maxTurnSpeed = 10f;

    [SerializeField]
    private float _turnAcceleration = 20f;

    private Rigidbody _rigidbody;

    private float _thrustInput;
    private float _turnInput;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _thrustInput = Input.GetAxis("Vertical");
        _turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 thrustForce = _thrustInput * _acceleration * gameObject.transform.forward;
        _rigidbody.AddForce(thrustForce, ForceMode.Acceleration);
        if(_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    private void Turn()
    {
        Vector3 turnForce = _turnInput * _turnAcceleration * gameObject.transform.up;
        _rigidbody.AddTorque(turnForce, ForceMode.Acceleration);
        if(_rigidbody.angularVelocity.magnitude > _maxTurnSpeed)
        {
            _rigidbody.angularVelocity = _rigidbody.angularVelocity.normalized * _maxTurnSpeed;
        }
    }
}
