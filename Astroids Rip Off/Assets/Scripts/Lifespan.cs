using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
