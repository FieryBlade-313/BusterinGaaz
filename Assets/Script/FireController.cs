using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float maxFireLength = 1f;
    public RocketMeshGenerator rmg;

    private Parameters param;

    private void Start()
    {
        param = rmg.GetComponent<Parameters>();
        CalculateDistanceFromInlet();
    }

    float getDistanceFromInlet()
    {
        Parameters.Params parameters = param.parameters;

        return 0.153f - (0.322f * parameters.angle) + (0.396f * parameters.areaOther) + (0.424f * parameters.areaCenter) + (0.0226f * parameters.areaConcentric)
                + (0.175f * parameters.angle * parameters.angle) + (0.0185f * parameters.areaOther * parameters.angle) - (0.0701f * parameters.areaOther * parameters.areaOther) - (0.251f * parameters.areaCenter * parameters.angle)
                + (0.179f * parameters.areaCenter * parameters.areaOther) + (0.0150f * parameters.areaCenter * parameters.areaCenter) + (0.0134f * parameters.areaConcentric * parameters.angle) + (0.0296f * parameters.areaConcentric * parameters.areaOther)
                + (0.0752f * parameters.areaConcentric * parameters.areaCenter) + (0.0192f * parameters.areaConcentric * parameters.areaConcentric);
    }

    public void CalculateDistanceFromInlet()
    {
        SetFireLength(getDistanceFromInlet());
    }

    public void SetFireOffset()
    {
        transform.parent.position = new Vector3(rmg.getIntersectionDistance(), transform.parent.position.y, transform.parent.position.z);
    }

    public void SetFireLength(float Xcc)
    {
        transform.parent.localScale = new Vector3(Mathf.Lerp(0.5f * 1f, 1f, Xcc), Mathf.Lerp(0.25f * maxFireLength, maxFireLength, Xcc), 1);
    }
}
