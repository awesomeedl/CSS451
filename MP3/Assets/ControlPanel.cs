using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public Slider Interval, Speed, LifeSpan;
    public Text IntervalText, SpeedText, LifeSpanText;
    // Start is called before the first frame update
    void Start()
    {
        Interval.value = AimLine.interval;
        Speed.value = AimLine.speed;
        LifeSpan.value = AimLine.lifeSpan;
    }

    public void UpdateParam()
    {
        AimLine.interval = Interval.value;
        AimLine.speed = Speed.value;
        AimLine.lifeSpan = LifeSpan.value;
    }
    // Update is called once per frame
    void Update()
    {
        updateText();
    }

    public void updateText()
    {
        IntervalText.text = Interval.value.ToString("F");
        SpeedText.text = Speed.value.ToString("F");
        LifeSpanText.text = LifeSpan.value.ToString("F");
    }
}
