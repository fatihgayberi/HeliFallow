using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    bool changeRotate; // aracin donusunu baslatir ve sonlandirir
    bool changingLane; // serit degisimini haber verir
    bool upDirection; // aracin yukari mi asagi mi serit degisecegini tutar
    public float rotationAngle = 0.5f; // Quaternion.Slerp e uygun bir aci tutar
    Quaternion deltaRotation; // yapacagi virajin keskinligini saklar
    Quaternion startRotation; // baslangic rotasyonlarını tutar
    public float rotateStartTime; // donusun ne zaman baslayacagini saklar
    public float rotateJourneyTime; // donusun ne kadar uzun surcegini saklar
    public float rotateSpeed; // donus hizini tutar
    float targetPosZ; // gidilecek olan yolun Z pozisyonunu saklar
    float speedZ; // serit degistirme hizini saklar

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        positionController(other);
    }

    // arcin seir degistirirkenki donme animasyonunu gercekler
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

    // aracin ne sekilde animasyon yapacagını belirler
    void positionController(Collider other)
    {
        // asagi yonde hareket edecek ise
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

        // yukari yonde hareket edecek ise
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
