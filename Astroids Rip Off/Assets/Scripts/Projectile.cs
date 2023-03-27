using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // because some of the childern classes want to do
    // stuff in start we have this delegate, it's a list
    // of all the different things we wanna do on start
    internal delegate void OnStart();
    internal List<OnStart> onStart = new List<OnStart>();

    [SerializeField]
    protected float _speed = 15f;

    [SerializeField]
    private float _spinForce = 0f;

    protected Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.velocity = _speed * gameObject.transform.forward;

        if(_spinForce > 0f)
        {
            _rigidbody.AddTorque(_spinForce * Random.insideUnitSphere);
        }
        // just goes through the delegate and does all of it's actions
        foreach(var start in onStart)
        {
            start();
        }
    }
}