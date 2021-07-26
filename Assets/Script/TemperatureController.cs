using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    public Gradient tempGradient;
    private Material tempMaterial;

    private Parameters param;

    public Text tf_max_text;
    public Text tt_max_text;
    private void Start()
    {
        param = FindObjectOfType<Parameters>();
        tempMaterial = GetComponent<MeshRenderer>().material;
        CalculateTemperature();
    }

    double getInjectorFaceHeatCap()
    {
        Parameters.Params parameters = param.parameters;
        return 0.692 + (0.477 * parameters.angle) - (0.687 * parameters.areaOther) - (0.080 * parameters.areaCenter) - (0.0650 * parameters.areaConcentric) - (0.167 * parameters.angle * parameters.angle)
                - (0.0129 * parameters.areaOther * parameters.angle) + (0.0796 * parameters.areaOther * parameters.areaOther) - (0.0634 * parameters.areaCenter * parameters.angle) - (0.0257 * parameters.areaCenter * parameters.areaOther)
                + (0.0877 * parameters.areaCenter * parameters.areaCenter) - (0.0521 * parameters.areaConcentric * parameters.angle) + (0.00156 * parameters.areaConcentric * parameters.areaOther) + (0.00198 * parameters.areaConcentric * parameters.areaCenter)
                + (0.0184 * parameters.areaConcentric * parameters.areaConcentric);
    }

    double getPostTipHeatCap()
    {
        Parameters.Params parameters = param.parameters;
        return 0.370 - (0.205 * parameters.angle) + (0.0307 * parameters.areaOther) + (0.108 * parameters.areaCenter) + (1.019 * parameters.areaConcentric)
                - (0.135 * parameters.angle * parameters.angle) + (0.0141 * parameters.areaOther * parameters.angle) + (0.0998 * parameters.areaOther * parameters.areaOther) + (0.208 * parameters.areaCenter * parameters.angle)
                - (0.0301 * parameters.areaCenter * parameters.areaOther) - (0.226 * parameters.areaCenter * parameters.areaCenter) + (0.353 * parameters.areaConcentric * parameters.angle) - (0.0497 * parameters.areaConcentric * parameters.areaCenter)
                - (0.423 * parameters.areaConcentric * parameters.areaConcentric) + (0.202 * parameters.areaOther * parameters.angle * parameters.angle) - (0.281 * parameters.areaCenter * parameters.angle * parameters.angle)
                - (0.342 * parameters.areaOther * parameters.areaOther * parameters.angle) - (0.245 * parameters.areaOther * parameters.areaOther * parameters.areaCenter) + (0.281 * parameters.areaCenter * parameters.areaCenter * parameters.areaOther)
                - (0.184 * parameters.areaConcentric * parameters.areaConcentric * parameters.angle) - (0.281 * parameters.areaOther * parameters.angle * parameters.areaCenter);
    }

    public void CalculateTemperature()
    {
        SetMeshTemperature(getInjectorFaceHeatCap(), getPostTipHeatCap());
    }

    public void SetMeshTemperature(double Tfmax,double TTmax)
    {
        tempMaterial.SetColor("_color1", tempGradient.Evaluate((float)Tfmax));
        tempMaterial.SetColor("_color2", tempGradient.Evaluate((float)TTmax));

        tf_max_text.text = Tfmax.ToString();
        tt_max_text.text = TTmax.ToString();
        tf_max_text.color = tempGradient.Evaluate((float)Tfmax);
        tt_max_text.color = tempGradient.Evaluate((float)TTmax);
    }
}
