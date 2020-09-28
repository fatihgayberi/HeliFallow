using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    bool changeRotate;
    bool changingLane;
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
        Rotate();
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        positionController(other);
    }

    void Rotate()
    {
        if (changeRotate)
        {
            float fracComplete = Mathf.PingPong(Time.time - rotateStartTime, rotateJourneyTime / rotateSpeed);
            transform.rotation = Quaternion.Slerp(deltaRotation, startRotation, fracComplete * rotateSpeed);
            if (transform.rotation == startRotation)
            {
                changeRotate = false;
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
            targetPosZ = (int)transform.position.z - 5f;
            deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
            changeRotate = true;
            changingLane = true;
        }
        if (other.CompareTag("UpPath"))
        {
            startRotation = transform.rotation;
            speedZ = 3f;
            rotationAngle = 60;
            targetPosZ = (int)transform.position.z + 5f;
            deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
            changeRotate = true;
            changingLane = true;
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

    public float GetTargetPosZ()
    {
        return targetPosZ;
    }

    public float GetSpeedZ()
    {
        return speedZ;
    }
}
