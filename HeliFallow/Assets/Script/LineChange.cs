using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    GameObject otherObject;
    bool changePosition;
    bool changeRotate;
    public float rotationAngle = 40f;
    Quaternion deltaRotation;
    Quaternion startRotation;
    Vector3 deltaPosition;
    Vector3 startPosition;
    public float rotateStartTime;
    public float rotateJourneyTime;
    public float rotateSpeed;
    public float positionStartTime;
    public float positionJourneyTime;
    public float positionSpeed;
    float posZ;

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
        PositionUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        otherObject = other.gameObject;
        positionController();
    }

    void Rotate()
    {
        if (changeRotate)
        {
            float fracComplete = Mathf.PingPong(Time.time - rotateStartTime, rotateJourneyTime / rotateSpeed);
            //otherObject.transform.rotation = Quaternion.Slerp(deltaRotation, startRotation, fracComplete * rotateSpeed);
            if (otherObject.transform.rotation == startRotation)
            {
                changeRotate = false;
            }
        }
    }

    void PositionUpdate()
    {
        if (changePosition)
        {
            float fracComplete = Mathf.PingPong(Time.time - positionStartTime, positionJourneyTime / positionSpeed);
            otherObject.transform.position = Vector3.Slerp(deltaPosition, startPosition, fracComplete * positionSpeed);
            if (otherObject.transform.position.z == posZ)
            {
                changePosition = false;
            }
        }
    }

    void positionController()
    {
        startRotation = otherObject.transform.rotation;

        if (CompareTag("DownPath"))
        {            
            posZ = otherObject.transform.position.z - 5f;
        }
        if (CompareTag("UpPath"))
        {
            rotationAngle *= -1;
            posZ = otherObject.transform.position.z + 5f;
        }
        deltaRotation = Quaternion.Euler(0, rotationAngle, 0);
        startPosition = otherObject.transform.position;
        deltaPosition = new Vector3(otherObject.transform.position.x, otherObject.transform.position.y, posZ);
        changePosition = true;
        changeRotate = true;
    }
}
