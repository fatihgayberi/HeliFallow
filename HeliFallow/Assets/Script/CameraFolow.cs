using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float distance; // Y
    public float space; // X
    public float perspective;

    private void Start()
    {
        PerspectiveSettings();
    }
    private void LateUpdate()
    {
        Follow();
    }

    // kamera takibini yapar
    void Follow()
    {
        Vector3 desiredPosition = new Vector3(space, distance, 0) + new Vector3 (target.position.x, target.position.y, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    // kameranin perspektifini ayarlar 
    void PerspectiveSettings()
    {
        transform.rotation = Quaternion.Euler(perspective, 90, transform.rotation.z);
    }

}
