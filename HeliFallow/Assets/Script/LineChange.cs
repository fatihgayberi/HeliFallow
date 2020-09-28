using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    bool changeRotate;
    bool changingLane;
    public float rotationAngle = 40f;
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
            transform.rotation = Quaternion.Slerp(deltaRotation, startRotation, Time.deltaTime * rotateSpeed);
            if (transform.rotation.y == 0f)
            {
                changeRotate = false;
            }
        }
    }

    void positionController(Collider other)
    {
        startRotation = transform.rotation;

        if (other.CompareTag("DownPath"))
        {
            speedZ = -3f;
            Mathf.Abs(rotationAngle);
            targetPosZ = (int)transform.position.z - 5f;
        }
        if (other.CompareTag("UpPath"))
        {
            speedZ = 3f;
            rotationAngle *= -1;
            targetPosZ = (int)transform.position.z + 5f;
        }
        deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
        changeRotate = true;
        changingLane = true;
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
