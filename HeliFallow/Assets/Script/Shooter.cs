using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] Slider shootSlider;
    [SerializeField] Button shootBtn;
    const float maxBarCross = 2.5f;
    float barCross;
    bool barCrossDecrease;
    bool barStopper;

    // Start is called before the first frame update
    void Start()
    {
        shootBtn.onClick.AddListener(ShootTouchPlay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootBar();
    }

    void ShootBar()
    {
        if (!barStopper)
        {
            if (!barCrossDecrease)
            {
                barCross += Time.deltaTime;
                SetBarCross(barCross);
                Debug.Log("time+: " + barCross);
    
                if (barCross >= maxBarCross)
                {
                    barCrossDecrease = true;
                }
            }
    
            if (barCrossDecrease)
            {
                barCross -= Time.deltaTime;
                SetBarCross(barCross);
                Debug.Log("time-: " + barCross);
    
                if (barCross <= 0)
                {
                    barCrossDecrease = false;
                }
            }
        }
    }

    public void BarCrossMax()
    {
        shootSlider.maxValue = maxBarCross;
    }

    void SetBarCross(float barCross)
    {
        shootSlider.value = barCross;
    }

    void ShootTouchPlay()
    {
        barStopper = true;
        Debug.Log("TA TA OLDUN CIK: " + shootSlider.value);
        ShootPossibility(shootSlider.value);
    }

    void ShootPossibility(float sliderValue)
    {
        int possibility = 0;
        int randNum = Random.Range(0, 100);

        if (sliderValue <= 0.5f)
        {
            // kirmizi
            possibility = 60;
        }
        else if (sliderValue <= 1f)
        {
            // sari
            possibility = 80;
        }
        else if (sliderValue <= 1.5f)
        {
            // yesil
            possibility = 100;
        }
        else if (sliderValue <= 2f)
        {
            // sari
            possibility = 80;
        }
        else if (sliderValue <= 2.5f)
        {
            // kirmizi
            possibility = 60;
        }

        if (randNum <= possibility)
        {
            Debug.Log("WINNER");
        }
        if (randNum > possibility)
        {
            Debug.Log("LOSER");
        }
    }
}
