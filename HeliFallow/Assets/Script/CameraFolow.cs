using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    //public Vector3 offset;
    public float skid; // Z
    float skidControl; // Z
    public float distance; // Y
    public float space; // X

    private void LateUpdate()
    {
        Follow();
    }

    // kamera takibini yapar
    void Follow()
    {
        if ((int)target.position.z == 0)
        {
            skidControl = target.position.z;
        }
        if (target.position.z > 0 && skid > 0)
        {
            skidControl = -skid;
        }
        if (target.position.z < 0 && skid < 0)
        {
            skidControl = -skid;
        }
        Vector3 desiredPosition = new Vector3(space, distance, skidControl) + target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
