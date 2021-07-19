using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDirectionController : MonoBehaviour
{

    public enum TriggerType {Top, Bottom};

    public TriggerType triggerType;

    PolygonCollider2D polyCollider;

    private Vector2 velDir = Vector2.zero;

    private Parameters param;
    private RocketMeshGenerator rmg;

    private ParticleSystemInfoScript psInfo;

    public void Initialize()
    {
        polyCollider = gameObject.AddComponent<PolygonCollider2D>();
        polyCollider.pathCount = 1;

        param = GetComponent<Parameters>();
        rmg = GetComponent<RocketMeshGenerator>();
        psInfo = GetComponent<ParticleSystemInfoScript>();

        switch(triggerType)
        {
            case TriggerType.Top:
                {
                    psInfo.SetCollider1(polyCollider);
                }break;
            case TriggerType.Bottom:
                {
                    psInfo.SetCollider3(polyCollider);
                }
                break;
        }

        SetTriggerDimension();
    }

    public void SetTriggerDimension()
    {
        Vector2 dir = param.getDirVector();
        switch (triggerType)
        {
            case TriggerType.Top: 
                {
                    Vector2[] path = { rmg.getVertex(2), rmg.getVertex(9), rmg.getVertex(19), rmg.getVertex(12) };
                    polyCollider.SetPath(0, path );
                    velDir = new Vector2(dir.y, dir.x);
                }
                break;

            case TriggerType.Bottom:
                {
                    Vector2[] path = { rmg.getVertex(2), rmg.getVertex(9), rmg.getVertex(19), rmg.getVertex(12) };
                    polyCollider.SetPath(0, path);
                    velDir = new Vector2(-dir.y, dir.x);
                }
                break;
        }
    }

    public Vector2 getDirection()
    {
        return velDir;
    }
}
