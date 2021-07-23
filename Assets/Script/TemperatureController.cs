using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public Gradient tempGradient;
    private Material tempMaterial;

    private Parameters param;
    private void Start()
    {
        param = FindObjectOfType<Parameters>();
        tempMaterial = GetComponent<MeshRenderer>().material;
        CalculateTemperature();
    }

    float getInjectorFaceHeatCap()
    {
        Parameters.Params parameters = param.parameters;
        return 0.692f + (0.477f * parameters.angle) - (0.687f * parameters.areaOther) - (0.080f * parameters.areaCenter) - (0.0650f * parameters.areaConcentric) - (0.167f * parameters.angle * parameters.angle)
                - (0.0129f * parameters.areaOther * parameters.angle) + (0.0796f * parameters.areaOther * parameters.areaOther) - (0.0634f * parameters.areaCenter * parameters.angle) - (0.0257f * parameters.areaCenter * parameters.areaOther)
                + (0.0877f * parameters.areaCenter * parameters.areaCenter) - (0.0521f * parameters.areaConcentric * parameters.angle) + (0.00156f * parameters.areaConcentric * parameters.areaOther) + (0.00198f * parameters.areaConcentric * parameters.areaCenter)
                + (0.0184f * parameters.areaConcentric * parameters.areaConcentric);
    }

    float getPostTipHeatCap()
    {
        Parameters.Params parameters = param.parameters;
        return 0.370f - (0.205f * parameters.angle) + (0.0307f * parameters.areaOther) + (0.108f * parameters.areaCenter) + (1.019f * parameters.areaConcentric)
                - (0.135f * parameters.angle * parameters.angle) + (0.0141f * parameters.areaOther * parameters.angle) + (0.0998f * parameters.areaOther * parameters.areaOther) + (0.208f * parameters.areaCenter * parameters.angle)
                - (0.0301f * parameters.areaCenter * parameters.areaOther) - (0.226f * parameters.areaCenter * parameters.areaCenter) + (0.353f * parameters.areaConcentric * parameters.angle) - (0.0497f * parameters.areaConcentric * parameters.areaCenter)
                - (0.423f * parameters.areaConcentric * parameters.areaConcentric) + (0.202f * parameters.areaOther * parameters.angle * parameters.angle) - (0.281f * parameters.areaCenter * parameters.angle * parameters.angle)
                - (0.342f * parameters.areaOther * parameters.areaOther * parameters.angle) - (0.245f * parameters.areaOther * parameters.areaOther * parameters.areaCenter) + (0.281f * parameters.areaCenter * parameters.areaCenter * parameters.areaOther)
                - (0.184f * parameters.areaConcentric * parameters.areaConcentric * parameters.angle) - (0.281f * parameters.areaOther * parameters.angle * parameters.areaCenter);
    }

    public void CalculateTemperature()
    {
        SetMeshTemperature(getInjectorFaceHeatCap(), getPostTipHeatCap());
    }

    public void SetMeshTemperature(float Tfmax,float TTmax)
    {
        tempMaterial.SetColor("_color1", tempGradient.Evaluate(Tfmax));
        tempMaterial.SetColor("_color2", tempGradient.Evaluate(TTmax));
    }
}
