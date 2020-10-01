using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTrigger : MonoBehaviour
{
    [SerializeField] GameObject shootPanel;
    [SerializeField] GameObject spotPanel;
    [SerializeField] Slider spotSlider; // spot butonunu dolduran bar
    const float time = 5f; // barin dolma sursi
    float timeCounter; // local zamani tutar
    bool timer;  // zaman sayacini baslatir durdurur


    private void Start()
    {
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
                SetShpotSlider(timeCounter);
                if (timeCounter >= time)
                {
                    spotPanel.gameObject.SetActive(false);
                    shootPanel.gameObject.SetActive(true);
                    //Debug.Log("win");
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
            SetShpotSlider(timeCounter);
            Debug.Log("time-: " + timeCounter);
        }
    }

    public void SpotSliderMax()
    {
        spotSlider.maxValue = time;
    }

    void SetShpotSlider(float timeCounter)
    {
        spotSlider.value = timeCounter;
    }

}
