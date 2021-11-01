using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void InitSliders()
    {
        Interval.InitSliderRange(0.5f, 4, BallSpawner.interval);
        Speed.InitSliderRange(0.5f, 15, BallSpawner.speed);
        LifeSpan.InitSliderRange(1, 15, BallSpawner.lifeSpan);

        Interval.SetSliderListener(UpdateInterval);
        Speed.SetSliderListener(UpdateSpeed);
        LifeSpan.SetSliderListener(UpdateLifeSpan);
    }
    void UpdateInterval(float param)
    {
        BallSpawner.interval = Interval.GetSliderValue();
    }
    void UpdateSpeed(float param)
    {
        BallSpawner.speed = Speed.GetSliderValue();
    }

    void UpdateLifeSpan(float param)
    {
        BallSpawner.lifeSpan = LifeSpan.GetSliderValue();
    }

    GameObject CreateAimLine(float y, float z)
    {
        return Instantiate(aimLinePrefab, new Vector3(0, y, z), Quaternion.identity);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
