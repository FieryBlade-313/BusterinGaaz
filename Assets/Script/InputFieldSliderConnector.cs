using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSliderConnector : MonoBehaviour
{
    InputField inputField;
    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void UpdateValue(float val)
    {
        inputField.text = val.ToString();
    }
}
