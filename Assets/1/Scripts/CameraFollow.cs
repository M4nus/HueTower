using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpped = 0.125f;

   public void FixedUpdate()
    {

        Vector3 desiredPosition = target.position+offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpped);
        transform.position = smoothedPosition;
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
