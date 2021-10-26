using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Controller : MonoBehaviour
{
    // Prefab
    public GameObject aimLinePrefab;

    // References
    public SliderWithEcho Interval, Speed, LifeSpan;
    public XformControl barrierCtrl;
    public Transform barrier;

    void Awake()
    {
        InitLayerMask();
    }

    void Start()
    {
        barrierCtrl.SetSelectedObject(barrier);
        InitSliders();
    }

    void Update()
    {
        CursorSelect();
    }

    void CreateAimLine(float y, float z)
    {
        Instantiate(aimLinePrefab, new Vector3(0, y, z), Quaternion.identity);
    }

    void InitSliders()
    {
        Interval.InitSliderRange(0.5f, 4, AimLine.interval);
        Speed.InitSliderRange(0.5f, 15, AimLine.speed);
        LifeSpan.InitSliderRange(1, 15, AimLine.lifeSpan);

        Interval.SetSliderListener(UpdateInterval);
        Speed.SetSliderListener(UpdateSpeed);
        LifeSpan.SetSliderListener(UpdateLifeSpan);
    }
    void UpdateInterval(float param)
    {
        AimLine.interval = Interval.GetSliderValue();
    }
    void UpdateSpeed(float param)
    {
        AimLine.speed = Speed.GetSliderValue();
    }

    void UpdateLifeSpan(float param)
    {
        AimLine.lifeSpan = LifeSpan.GetSliderValue();
    }

}
