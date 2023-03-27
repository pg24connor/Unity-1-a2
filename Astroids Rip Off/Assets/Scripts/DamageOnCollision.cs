using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField]
    private float _damage = 1f;

    [SerializeField]
    private int _team = 0;

    [SerializeField]
    private float _minVelocity = 5f;

    [SerializeField]
    private bool _destroyOnCollision = false;

    private void TryDamage(Collider other)
    {
        if(other.TryGetComponent(out Health target) == true && target.Team != _team)
        {
            target.ApplyDamage(_damage);
            if(_destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TryDamage(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= _minVelocity)
        {
            TryDamage(collision.collider);
        }
    }
}
