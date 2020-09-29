using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTrigger : MonoBehaviour
{
    [SerializeField] Slider shotSlider; // shot butonunu dolduran bar
    [SerializeField] Button shotButton; // ates etme butonu
    const float time = 5f; // barin dolma sursi
    float timeCounter; // local zamani tutar
    bool timer;  // zaman sayacini baslatir durdurur


    private void Start()
    {
        shotButton.onClick.AddListener(ShotTouchPlay);
    }

    void FixedUpdate()
    {
        TimeController();
    }

    // thief ile spot kesistigi surece sayaci arttirir.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            timer = false;

            if (timeCounter < time)
            {
                timeCounter += Time.deltaTime;
                Debug.Log("time+: " + timeCounter);
                SetShotSlider(timeCounter);
                if (timeCounter >= time)
                {
                    shotSlider.gameObject.SetActive(false);
                    shotButton.gameObject.SetActive(true);
                    Debug.Log("win");
                }
            }
        }
    }

    // spot thief ile temasi bitirdiginde zamani azaltmak icin calisir
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            timer = true;
        }
    }

    // saniye sayacini azaltir
    void TimeController()
    {
        if (timer && timeCounter > 0 && timeCounter < time)
        {
            timeCounter -= Time.deltaTime;
            SetShotSlider(timeCounter);
            Debug.Log("time-: " + timeCounter);
        }
    }

    public void ShotSliderMax()
    {
        shotSlider.maxValue = time;
    }

    void SetShotSlider(float timeCounter)
    {
        shotSlider.value = timeCounter;
    }

    void ShotTouchPlay()
    {
        Debug.Log("TA TA oldun cik");
    }
}
