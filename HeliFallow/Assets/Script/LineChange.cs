using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    Rigidbody rbThief;
    [SerializeField] float speed; // aracin dikey yonde ilerlemesi icin hizi
    [SerializeField] float rotateSpeed; // donus hizini tutar
    bool changingLane; // serit degisimini haber verir
    bool upDirection; // aracin yukari mi asagi mi serit degisecegini tutar
    float targetPosZ; // gidilecek olan yolun Z pozisyonunu saklar
    float speedZ; // serit degistirme hizini saklar
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rbThief = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    // thiefin hareket etmesini saglar
    void Move()
    {
        // duz bir hizada ilerlemesini saglar
        if (!changingLane)
        {
            rbThief.velocity = new Vector3(speed, 0, 0);
        }
        // serit degistirirken capraz ilerlemesini saglar
        if (changingLane)
        {
            rbThief.velocity = new Vector3(speed, 0, speedZ);
    
            // en alt seride gecmesini kontrol eder
            if (targetPosZ < 0 && transform.position.z <= targetPosZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (int)targetPosZ);
                changingLane = false;
            }
            // en ust seride gecmesini kontrol eder
            if (targetPosZ > 0 && transform.position.z >= targetPosZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (int)targetPosZ);
                changingLane = false;
            }
            // orta seritten en ust seride gecmesini kontrol eder
            if (targetPosZ == 0 && upDirection && transform.position.z >= targetPosZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (int)targetPosZ);
                changingLane = false;
            }
            // orta seritten en alt seride gecmesini kontrol eder
            else if (targetPosZ == 0 && !upDirection && transform.position.z <= targetPosZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (int)targetPosZ);
                changingLane = false;
            }
        }
    
    }//itewen

    private void OnTriggerEnter(Collider other)
    {
        positionController(other);
    }

    // aracin ne sekilde animasyon yapacagını belirler
    void positionController(Collider other)
    {
        // asagi yonde hareket edecek ise
        if (other.CompareTag("DownPath"))
        {
            StartCoroutine(AnimatorSetFire("Right"));
            changingLane = true;
            upDirection = false;
            speedZ = -3f;
            targetPosZ = Mathf.Round(transform.position.z) - 5f;
        }

        // yukari yonde hareket edecek ise
        if (other.CompareTag("UpPath"))
        {
            StartCoroutine(AnimatorSetFire("Left"));
            changingLane = true;
            upDirection = true;
            speedZ = 3f;
            targetPosZ = Mathf.Round(transform.position.z) + 5f;
        }
        else if (other.CompareTag("PathEnd"))
        {
            GetComponent<LineChange>().enabled = false;
        }
    }

    private IEnumerator AnimatorSetFire(string animationName)
    {
        anim.SetBool(animationName, true);

        yield return new WaitForSeconds(1.5f);

        anim.SetBool(animationName, false);
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
