using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    [SerializeField]
    private int _team = 0;

    [SerializeField]
    private float _homingRange = 15f;

    [SerializeField]
    private LayerMask _targetLayer;

    private Collider[] _hitColliders = new Collider[10];
    private Transform _target;

    private void FixedUpdate()
    {
        _target = GetNearestTarget(GetEnemiesInRange(_homingRange));
        Homing();
    }

    private Collider[] GetEnemiesInRange(float homingRange)
    {
        return Physics.OverlapSphere(transform.position, homingRange, _targetLayer);
    }

    private Transform GetNearestTarget(Collider[] targets)
    {
        Transform nearestTarget = null;
        float minDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        foreach (Collider target in targets) 
        {
            if(target != null)
            {
                float dist = Vector3.Distance(currentPosition, target.transform.position);
                if(dist < minDistance)
                {
                    minDistance = dist;
                    nearestTarget = target.transform;
                }
            }
        }

        return nearestTarget;
    }

    private void Homing()
    {
        if(_target == null)
        {
            _rigidbody.angularVelocity = Vector3.zero;
            return;
        }

        Vector3 dir = (_target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);

        transform.rotation = rotation;
        _rigidbody.velocity = transform.forward * _speed;
    }
}
