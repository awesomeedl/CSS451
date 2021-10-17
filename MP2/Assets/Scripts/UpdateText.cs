using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateText : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public void updateText()
    {
        text.text = slider.value.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        // slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
