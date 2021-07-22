using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public Gradient tempGradient;
    private Material tempMaterial;

    [Range(0,1)]
    public float _test_TfMax;
    [Range(0,1)]
    public float _test_TTMax;

    private void Start()
    {
        tempMaterial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        SetMeshTemperature(_test_TfMax, _test_TTMax);
    }

    public void SetMeshTemperature(float Tfmax,float TTmax)
    {
        tempMaterial.SetColor("_color1", tempGradient.Evaluate(Tfmax));
        tempMaterial.SetColor("_color2", tempGradient.Evaluate(TTmax));
    }
}
