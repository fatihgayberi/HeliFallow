using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTrigger : MonoBehaviour
{
    [SerializeField] Slider shotSlider;
    [SerializeField] Button shotButton;
    const float time = 5f;
    float timeCounter;
    bool timer;


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

    // spot thief ile temasi bitirdiginde zamani azaltmak icin calisir
    private void OnTriggerExit(Collider other)
    {
        timer = true;
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
