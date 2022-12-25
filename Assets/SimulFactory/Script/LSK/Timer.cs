using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    public GameObject sliderObject;
    public float currentTime = 5;

    private TextMeshProUGUI time;
    private Slider slider;

    private void Awake()
    {
        time = timer.GetComponent<TextMeshProUGUI>();
        slider = sliderObject.GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = currentTime;
    }

    private void Update()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            slider.value = currentTime;

            time.text = string.Format("{0:N1}", currentTime);
        }
        else
        {
            currentTime = 0;
            time.text = "0";
        }
    }
}
