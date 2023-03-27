using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shotgun : Projectile
{
    [SerializeField]
    private int _bulletCount = 5;

    [Range(0f, 180f)]
    [SerializeField]
    private float _spreadAngle = 30f;

    // because I made the shotgun a part of the projectile
    // system we are using I had to change it up a little
    // all I really changed is now we drag and drop the
    // bullet prefab into the shotgun prefab
    [SerializeField]
    private GameObject _bullet;

    private void Awake()
    {
        // little bit of delegate action, we have a 
        // a list of delegates in the parent projectile
        // class and a foreach loop that calls all of them
        // on start, we do this because having two starts
        // doesn't seem to work
        onStart.Add(new OnStart(ShotgunStart));
    }

    private void ShotgunStart()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            float angle = (i * _spreadAngle / (_bulletCount - 1)) - (_spreadAngle * 0.5f);

            Quaternion forward = Quaternion.Euler(0f, angle, 0f) * transform.rotation;

            Instantiate(_bullet, transform.position, forward);
        }
        Destroy(gameObject);
    }
}
