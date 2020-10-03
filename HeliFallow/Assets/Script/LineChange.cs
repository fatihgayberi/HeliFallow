using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChange : MonoBehaviour
{
    Rigidbody rbThief;
    [SerializeField] float speed; // aracin dikey yonde ilerlemesi icin hizi
    [SerializeField] float rotateSpeed; // donus hizini tutar
    bool changingLane; // serit degisimini haber verir
    bool leftDirection; // aracin yukari mi asagi mi serit degisecegini tutar
    float targetPosX; // gidilecek olan yolun Z pozisyonunu saklar
    float speedX; // serit degistirme hizini saklar
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
            rbThief.velocity = new Vector3(0, 0, speed);
        }
        // serit degistirirken capraz ilerlemesini saglar
        if (changingLane)
        {
            rbThief.velocity = new Vector3(speedX, 0, speed);
    
            // orta seritten sag seride gecmesini kontrol eder
            if (targetPosX > 0 && transform.position.x >= targetPosX)
            {
                transform.position = new Vector3((int)targetPosX, transform.position.y, transform.position.z);
                changingLane = false;
            }
            // sol seride gecmesini kontrol eder
            if (targetPosX < 0 && transform.position.x <= targetPosX)
            {
                transform.position = new Vector3((int)targetPosX, transform.position.y, transform.position.z);
                changingLane = false;
            }
            // sag seritten orta serite gecmesini kontrol eder
            if (targetPosX == 0 && leftDirection && transform.position.x <= targetPosX)
            {
                transform.position = new Vector3((int)targetPosX, transform.position.y, transform.position.z);
                changingLane = false;
            }
            // sag seritten orta seride gecmesini kontrol eder
            else if (targetPosX == 0 && !leftDirection && transform.position.x >= targetPosX)
            {
                transform.position = new Vector3((int)targetPosX, transform.position.y, transform.position.z);
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
        if (other.CompareTag("RightPath"))
        {
            StartCoroutine(AnimatorSetFire("Right"));
            changingLane = true;
            leftDirection = false;
            speedX = 3f;
            targetPosX = Mathf.Round(transform.position.x) + 5f;
        }

        // yukari yonde hareket edecek ise
        if (other.CompareTag("LeftPath"))
        {
            StartCoroutine(AnimatorSetFire("Left"));
            changingLane = true;
            leftDirection = true;
            speedX = -3f;
            targetPosX = Mathf.Round(transform.position.x) - 5f;
        }
        if (other.CompareTag("PathEnd"))
        {
            rbThief.velocity = Vector3.zero;
            this.GetComponent<LineChange>().enabled = false;
        }
    }

    private IEnumerator AnimatorSetFire(string animationName)
    {
        anim.SetBool(animationName, true);

        yield return new WaitForSeconds(1);

        anim.SetBool(animationName, false);
    }
}
