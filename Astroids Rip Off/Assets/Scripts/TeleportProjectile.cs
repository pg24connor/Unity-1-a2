using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportProjectile : Projectile
{
    // how long until the player jumps to the bullet position
    [SerializeField]
    private float _countDown = 1;

    // the bounds of the screen
    // we need to know this so we don't teleport off screen
    private Vector3 _bounds;

    private void Awake()
    {
        // little bit of delegate action, we have a 
        // a list of delegates in the parent projectile
        // class and a foreach loop that calls all of them
        // on start, we do this because having two starts
        // doesn't seem to work
        onStart.Add(new OnStart(teleSet));
    }

    /// <summary>
    /// what we would have in a start function
    /// it gets called in the projectile start function
    /// </summary>
    private void teleSet()
    {
        // little unnessary but I did for the sake of convience
        // instead of creating a whole new varible I just used
        // an existing one that wasn't being used for anything
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        // just set up the bounds stuff, we find the wrapper
        // we're gonna use it's size to determin if we can teleport
        _bounds = GameObject.FindGameObjectWithTag("Wrapper").GetComponent<BoxCollider>().size;
        // call the count down, when the count down hits zero we teleport
        StartCoroutine(teleCountDown());
        
    }

    /// <summary>
    /// if were not in bounds it returns before everything else
    /// if we don't return right away we just move the player
    /// (which is our parent right now) to where the bullet is
    /// then we destroy ourself
    /// </summary>
    private void Teleport()
    {
        if (!InBounds()) return;
        transform.parent.position = transform.position;
        Destroy(gameObject);
    }

    /// <summary>
    /// waits an varible amount of time and then teleports then player
    /// </summary>
    private IEnumerator teleCountDown()
    {
        yield return new WaitForSeconds(_countDown);
        Teleport();
    }

    /// <summary>
    /// just a simple function to figure out if the bullet is actually in 
    /// the playable space
    /// </summary>
    /// <returns> true if we are false if we aren't </returns>
    private bool InBounds()
    {
        Debug.Log(Mathf.Abs(transform.position.x));

        if (Mathf.Abs(transform.position.x) > _bounds.x) return false;
        if (Mathf.Abs(transform.position.z) > _bounds.z) return false;

        return true;
    }
}
