using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _cooldown = 0.2f;

    // all the different inputs for shooting
    [SerializeField]
    private KeyCode[] _input =
    {
        KeyCode.Mouse0,
        KeyCode.Mouse1,
        KeyCode.Mouse2
    };

    // all the different types of bullets
    [SerializeField]
    protected Projectile[] _bulletTypes;

    private bool _onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        // make sure the desigenrs can't mess up
        // if they try to create and in-equal amount
        // of inputs or bullets they'll get an error in
        // the console
        if (_input.Length != _bulletTypes.Length) throw new IndexOutOfRangeException("Inputs aren't equal to bullet types");

        // go through all the bullets and shoot em if
        // their corosponding input is pressed
        for(int i = 0; i < _bulletTypes.Length; i++)
        {
            if (Input.GetKey(_input[i]) && _onCooldown == false)
            {
                Shoot(_bulletTypes[i]);
            }
        }
    }
    // slightly modified, just added a parameter
    // for the type of bullet to shoot had to this
    // because now we're shooting more than just
    // the HomingProjectile
    protected void Shoot(Projectile bulletType)
    {
        Instantiate(bulletType, transform.position, transform.rotation);
        StartCoroutine(CooldownCoro());
    }

    protected IEnumerator CooldownCoro()
    {
        _onCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _onCooldown = false;
    }
}
