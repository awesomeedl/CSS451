using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XformControl : MonoBehaviour
{
    public Controller controller;

    [Header("Name")]
    public Text objName;
    [Header("Mode Selection")]
    public Toggle translation;
    public Toggle scaling;
    public Toggle rotation;
    [Header("Sliders")]
    public Slider X;
    public Slider Y;
    public Slider Z;

    public bool shouldChange = false;

    public enum Mode {
        Translation,
        Scaling,
        Rotation
    }

    const int maxTranslation = 10;
    const int maxScale = 3;
    const int maxRotation = 180;

    public Mode currentMode = Mode.Translation;

    GameObject cachedObject;
    // Start is called before the first frame update

    public void UpdateUI(GameObject objTransform)
    {
        cachedObject = objTransform;
        objName.text = objTransform.name;

        UpdateUI();
    }

    public void UpdateUI()
    {
        shouldChange = false;
        if(cachedObject != null)
        {
            switch(currentMode)
            {
                case Mode.Translation:
                    X.value = cachedObject.transform.localPosition.x;
                    Y.value = cachedObject.transform.localPosition.y;
                    Z.value = cachedObject.transform.localPosition.z;
                    break;
                case Mode.Scaling:
                    X.value = cachedObject.transform.localScale.x;
                    Y.value = cachedObject.transform.localScale.y;
                    Z.value = cachedObject.transform.localScale.z;
                    break;
                case Mode.Rotation:
                    X.value = cachedObject.transform.localRotation.eulerAngles.x;
                    Y.value = cachedObject.transform.localRotation.eulerAngles.y;
                    Z.value = cachedObject.transform.localRotation.eulerAngles.z;
                    break;
                default:
                    break;
            }
        }
        shouldChange = true;
    }

    public void UpdateObject()
    {
        if(shouldChange && cachedObject!= null)
        {
            switch(currentMode)
            {
                case Mode.Translation:
                    controller.ChangeTranslation(new Vector3(X.value, Y.value, Z.value));
                    break;
                case Mode.Scaling:
                    controller.ChangeScale(new Vector3(X.value, Y.value, Z.value));
                    break;
                case Mode.Rotation:
                    controller.ChangeRotation(new Vector3(X.value, Y.value, Z.value));
                    break;
                default:
                    break;
            }
        }

        //Debug.Log("UpdateObj called");
    }

    public void ChangeMode()
    {
        shouldChange = false;
        if(translation.isOn)
        {
            currentMode = Mode.Translation;
            
            X.maxValue = maxTranslation;
            X.minValue = -maxTranslation;
            Y.maxValue = maxTranslation;
            Y.minValue = -maxTranslation;
            Z.maxValue = maxTranslation;
            Z.minValue = -maxTranslation;

        }
        else if(scaling.isOn)
        {
            currentMode = Mode.Scaling;

            X.maxValue = maxScale;
            X.minValue = 0;
            Y.maxValue = maxScale;
            Y.minValue = 0;
            Z.maxValue = maxScale;
            Z.minValue = 0;
        }
        else
        {
            currentMode = Mode.Rotation;

            X.maxValue = maxRotation;
            X.minValue = -maxRotation;
            Y.maxValue = maxRotation;
            Y.minValue = -maxRotation;
            Z.maxValue = maxRotation;
            Z.minValue = -maxRotation;
        }

        UpdateUI();
    }


    void Start()
    {
        ChangeMode();
        //UpdateUI();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
