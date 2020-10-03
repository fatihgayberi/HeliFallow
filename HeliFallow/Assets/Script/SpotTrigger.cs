using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTrigger : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] GameObject shootPanel;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spotPanel;
    [SerializeField] Slider spotSlider; // spot butonunu dolduran bar
    const float spotMaxTime = 5f; // spot barin dolma sursi
    float timeCounter; // local zamani tutar
    bool timer;  // zaman sayacini baslatir durdurur

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

            if (timeCounter < spotMaxTime)
            {
                timeCounter += Time.deltaTime;
                Debug.Log("time+: " + timeCounter);
                SetShpotSlider(timeCounter);

                if (timeCounter >= spotMaxTime)
                {
                    spotPanel.gameObject.SetActive(false);
                    camera.GetComponent<CameraFolow>().enabled = false;
                    bullet.gameObject.SetActive(true);
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
        if (timer && timeCounter > 0 && timeCounter < spotMaxTime)
        {
            timeCounter -= Time.deltaTime;
            SetShpotSlider(timeCounter);
            Debug.Log("time-: " + timeCounter);
        }
    }

    public void SpotSliderMax()
    {
        spotSlider.maxValue = spotMaxTime;
    }

    void SetShpotSlider(float timeCounter)
    {
        spotSlider.value = timeCounter;
    }
}
