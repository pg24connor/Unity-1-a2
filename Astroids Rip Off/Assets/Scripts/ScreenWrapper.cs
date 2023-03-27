using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    // Camera so I can set the bounds and box collider for the wrapping action
    [SerializeField]
    private Camera _mainCamera;
    private BoxCollider _boxCollider;

    // Set the box collider and change it's size
    void Start()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider>();
        _boxCollider.size = CalculateSize();
    }

    /// <summary>
    /// Calculates the nessary size for the screen wrapper, 
    /// only works for orthagraphic Not nessary to the 
    /// assignment but it was bothering me
    /// </summary>
    /// <returns> Size for a box collider </returns>
    public Vector3 CalculateSize()
    {
        // the height of the camera is equal to 2x the
        // orthgraphic size and the width is equal to
        // the orthagraphic size times the aspec ratio
        // times 2
        float x = _mainCamera.orthographicSize * _mainCamera.aspect * 2;
        float y = 10;
        float z = _mainCamera.orthographicSize * 2;

        // for our game the x of the bounding box is
        // the width of the camera and the z is the
        // height, we set the y to 10 because it just
        // kinda looks right
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// when any game object exits the screen make
    /// it's position equal the the other side of 
    /// the screen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Vector3 min = _boxCollider.bounds.min;
        Vector3 max = _boxCollider.bounds.max;

        Vector3 otherPosition = other.transform.position;

        if (otherPosition.z > max.z || otherPosition.z < min.z)
        {
            otherPosition.z *= -1;
        }
        if (otherPosition.x > max.x || otherPosition.x < min.x)
        {
            otherPosition.x *= -1;
        }
        other.transform.position = otherPosition;
    }
}
