using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public float maxFireLength = 1f;
    public RocketMeshGenerator rmg;

    private Parameters param;
    public Text xcc_text;

    private void Start()
    {
        param = rmg.GetComponent<Parameters>();
        CalculateDistanceFromInlet();
    }

    double getDistanceFromInlet()
    {
        Parameters.Params parameters = param.parameters;

        return 0.153 - (0.322 * parameters.angle) + (0.396 * parameters.areaOther) + (0.424 * parameters.areaCenter) + (0.0226 * parameters.areaConcentric)
                + (0.175 * parameters.angle * parameters.angle) + (0.0185 * parameters.areaOther * parameters.angle) - (0.0701 * parameters.areaOther * parameters.areaOther) - (0.251 * parameters.areaCenter * parameters.angle)
                + (0.179 * parameters.areaCenter * parameters.areaOther) + (0.0150 * parameters.areaCenter * parameters.areaCenter) + (0.0134 * parameters.areaConcentric * parameters.angle) + (0.0296 * parameters.areaConcentric * parameters.areaOther)
                + (0.0752 * parameters.areaConcentric * parameters.areaCenter) + (0.0192 * parameters.areaConcentric * parameters.areaConcentric);
    }

    public void CalculateDistanceFromInlet()
    {
        SetFireLength(getDistanceFromInlet());
    }

    public void SetFireOffset()
    {
        transform.parent.position = new Vector3(rmg.getIntersectionDistance(), transform.parent.position.y, transform.parent.position.z);
    }

    public void SetFireLength(double Xcc)
    {
        transform.parent.localScale = new Vector3(Mathf.Lerp(0.5f * 1f, 1f, (float)Xcc), Mathf.Lerp(0.25f * maxFireLength, maxFireLength, (float)Xcc), 1);
        xcc_text.text = Xcc.ToString();
    }
}
