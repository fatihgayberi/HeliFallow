using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    Rigidbody rbThief;
    bool changeRotateDown; // aracin asagiya donusunu baslatir ve sonlandirir
    bool changeRotateUp; // aracin yukariya donusunu baslatir ve sonlandirir
    bool changingLane; // serit degisimini haber verir
    bool upDirection; // aracin yukari mi asagi mi serit degisecegini tutar
    public float rotationAngle = 0.5f; // Quaternion.Slerp e uygun bir aci tutar
    Quaternion deltaRotation; // yapacagi virajin keskinligini saklar
    Quaternion startRotation = new Quaternion(); // baslangic rotasyonlarını tutar
    public float rotateStartTime; // donusun ne zaman baslayacagini saklar
    public float rotateJourneyTime; // donusun ne kadar uzun surcegini saklar
    public float rotateSpeed; // donus hizini tutar
    float targetPosZ; // gidilecek olan yolun Z pozisyonunu saklar
    float speedZ; // serit degistirme hizini saklar
    bool rotate;
    float lerpValue;
    public float lerpRatio;


    private void Start()
    {
        startRotation = gameObject.transform.rotation;
        rbThief = GetComponent<Rigidbody>();    
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        positionController(other);
    }

    // aracin seyir degistirirkenki donme animasyonunu gercekler
    void Rotate()
    {
        if (rotate)
        {
            if (changeRotateDown)
            {
                Debug.Log("asdf");
                //lerpValue = Time.deltaTime / lerpRatio;
                //Debug.Log(":::" + transform.rotation.eulerAngles.y);
                float fracComplete = Mathf.PingPong(Time.unscaledTime - rotateStartTime, rotateJourneyTime / rotateSpeed);
                transform.rotation = Quaternion.Slerp(startRotation, deltaRotation, fracComplete);
                if (transform.rotation.eulerAngles.y <= 93)
                {
                    changeRotateDown = false;
                    transform.rotation = startRotation;//new Quaternion(0, startRotation, 0, transform.rotation.w);
                    Debug.Log("After: " + transform.rotation.eulerAngles.y);
                }
            }
        }
        if (changeRotateUp)
        {
            Debug.Log("asdf");
            //lerpValue = Time.deltaTime / lerpRatio;
            //Debug.Log(":::" + transform.rotation.eulerAngles.y);
            float fracComplete = Mathf.PingPong(Time.unscaledTime - rotateStartTime, rotateJourneyTime / rotateSpeed);
            transform.rotation = Quaternion.Slerp(startRotation, deltaRotation, fracComplete);
            if (transform.rotation.eulerAngles.y >= 87)
            {
                changeRotateUp = false;
                transform.rotation = startRotation;//new Quaternion(0, startRotation, 0, transform.rotation.w);
                Debug.Log("After: " + transform.rotation.eulerAngles.y);
            }

        }
    }

    void RotateBack()
    {

    }

    // aracin ne sekilde animasyon yapacagını belirler
    void positionController(Collider other)
    {
        // asagi yonde hareket edecek ise
        if (other.CompareTag("DownPath"))
        {
            Debug.Log("num1");
            rotate = true;
            //startRotation = transform.rotation.y;
            speedZ = -3f;
            rotationAngle = 120f;
            targetPosZ = Mathf.Round(transform.position.z) - 5f;
            deltaRotation = Quaternion.Euler(new Vector3(0, rotationAngle, 0));
            Debug.Log(deltaRotation);
            Debug.Log(deltaRotation.eulerAngles);
            changeRotateDown = true;
            changingLane = true;
            upDirection = false;
        }

        // yukari yonde hareket edecek ise
        if (other.CompareTag("UpPath"))
        {
            Debug.Log("num2");
            rotate = true;
            //startRotation = transform.rotation.y;
            speedZ = 3f;
            rotationAngle = 60f;
            targetPosZ = Mathf.Round(transform.position.z) + 5f;
            deltaRotation = Quaternion.Euler(new Vector3(0, rotationAngle, 0));
            changeRotateUp = true;
            changingLane = true;
            upDirection = true;
        }
        else if (other.CompareTag("PathEnd"))
        {
            GetComponent<ThiefMoved>().enabled = false;
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
