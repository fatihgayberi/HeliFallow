using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    bool changeRotate;
    bool changingLane;
    bool upDirection;
    public float rotationAngle = 0.5f;
    Quaternion deltaRotation;
    Quaternion startRotation;
    public float rotateStartTime;
    public float rotateJourneyTime;
    public float rotateSpeed;
    float targetPosZ;
    float speedZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        positionController(other);
    }

    void Rotate()
    {
        if (changeRotate)
        {
            float fracComplete = Mathf.PingPong(Time.unscaledTime - rotateStartTime, rotateJourneyTime / rotateSpeed);
            transform.rotation = Quaternion.Slerp(deltaRotation, startRotation, fracComplete * rotateSpeed);
            if (transform.rotation == startRotation)
            {
                changeRotate = false;
                transform.rotation = Quaternion.Euler(0, 90f, 0);
            }
        }
    }

    void positionController(Collider other)
    {

        if (other.CompareTag("DownPath"))
        {
            startRotation = transform.rotation;
            speedZ = -3f;
            rotationAngle = 120;
            targetPosZ = Mathf.Round(transform.position.z) - 5f;
            deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
            changeRotate = true;
            changingLane = true;
            upDirection = false;
        }
        if (other.CompareTag("UpPath"))
        {
            startRotation = transform.rotation;
            speedZ = 3f;
            rotationAngle = 60;
            targetPosZ = Mathf.Round(transform.position.z) + 5f;
            deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
            changeRotate = true;
            changingLane = true;
            upDirection = true;
        }

    }

    public bool GetChangingLane()
    {
        return changingLane;
    }

    public void SetChangingLane(bool changingLane)
    {
        this.changingLane = changingLane;
    }

    public bool GetUpDirection() 
    {
        return upDirection;
    }

    public float GetTargetPosZ()
    {
        return targetPosZ;
    }

    public float GetSpeedZ()
    {
        return speedZ;
    }
}
