using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float maxFireLength = 1f;
    public RocketMeshGenerator rmg;

    public void DebugLengthSetter()
    {
        SetFireLength(rmg.GetComponent<Parameters>().parameters.Xcc);
    }

    public void SetFireOffset()
    {
        transform.parent.position = new Vector3(rmg.getIntersectionDistance(), transform.parent.position.y, transform.parent.position.z);
    }

    public void SetFireLength(float Xcc)
    {
        transform.parent.localScale = new Vector3(Mathf.Lerp(0.5f * 1f, 1f, Xcc), Mathf.Lerp(0.25f * maxFireLength, maxFireLength, Xcc), 1);
    }

    private void Update()
    {
        DebugLengthSetter();
    }
}
