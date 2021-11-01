using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class Controller : MonoBehaviour
{
    // Prefab
    public GameObject aimLinePrefab;

    // References
    public SliderWithEcho Interval, Speed, LifeSpan, OSpeed, ORadius;
    public XformControl barrierCtrl;
    public Transform barrier;

    public Toggle OrbitToggle;

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
        OSpeed.InitSliderRange(0.1f, Mathf.PI * 2f, BallSpawner.orbitSpeed);
        ORadius.InitSliderRange(0f, 5f, BallSpawner.orbitRadius);

        Interval.SetSliderListener(UpdateInterval);
        Speed.SetSliderListener(UpdateSpeed);
        LifeSpan.SetSliderListener(UpdateLifeSpan);
        OSpeed.SetSliderListener(UpdateOSpeed);
        ORadius.SetSliderListener(UpdateORadius);
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

    void UpdateOSpeed(float param)
    {
        BallSpawner.orbitSpeed = OSpeed.GetSliderValue();
    }

    void UpdateORadius(float param)
    {
        BallSpawner.orbitRadius = ORadius.GetSliderValue();
    }

    GameObject CreateAimLine(float y, float z)
    {
        return Instantiate(aimLinePrefab, new Vector3(0, y, z), Quaternion.identity);
    }

    public void ToggleOrbitCtrl()
    {

        BallSpawner.orbitSpeed = OrbitToggle.isOn ? OSpeed.GetSliderValue() : 0f;
        BallSpawner.orbitRadius = OrbitToggle.isOn ? ORadius.GetSliderValue() : 0f;

        OSpeed.gameObject.SetActive(OrbitToggle.isOn);
        ORadius.gameObject.SetActive(OrbitToggle.isOn);
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
