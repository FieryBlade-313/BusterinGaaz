using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInputFieldConnector : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateValue(string value)
    {
        try
        {
            slider.value = float.Parse(value);
        }
        catch
        {
            Debug.Log("Not a number");
        }
    }

    
}
