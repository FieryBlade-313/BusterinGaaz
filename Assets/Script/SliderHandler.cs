using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{

    Parameters param;

    public Slider angleSlider;
    public Slider areaCenterSlider;
    public Slider areaConcentricSlider;
    public Slider areaOtherSlider;

    public InputField angleInputField;
    public InputField areaCenterInputField;
    public InputField areaConcentricInputField;
    public InputField areaOtherInputField;


    // Start is called before the first frame update
    void Start()
    {
        param = GetComponent<Parameters>();
        angleSlider.value = param.parameters.angle;
        areaCenterSlider.value = param.parameters.areaCenter;
        areaConcentricSlider.value = param.parameters.areaConcentric;
        areaOtherSlider.value = param.parameters.areaOther;

        angleInputField.text = param.parameters.angle.ToString();
        areaCenterInputField.text = param.parameters.areaCenter.ToString();
        areaConcentricInputField.text = param.parameters.areaConcentric.ToString();
        areaOtherInputField.text = param.parameters.areaOther.ToString();

        GetComponent<RocketMeshGenerator>().CalculateMeshInfo();
        GetComponent<ParticleEmitterShapeModifier>().SetEmittersShape();
        GetComponent<TriggerColliderSetter>().InitializeParticleDirection();

    }
}
