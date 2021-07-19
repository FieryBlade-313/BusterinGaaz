using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitterShapeModifier : MonoBehaviour
{
    Parameters param;
    ParticleSystemInfoScript psInfo;

    private void Start()
    {
        param = GetComponent<Parameters>();
        psInfo = GetComponent<ParticleSystemInfoScript>();

        SetEmittersShape();
    }

    public void SetEmittersShape()
    {
        ParticleSystemInfoScript.emitterData emitter1Data = psInfo.getEmitter1();

        ChangeShapeByEmitterType(emitter1Data);

    }

    public void ChangeShapeByEmitterType( ParticleSystemInfoScript.emitterData emData )
    {
        float pos = 0, area = 0;

        switch(emData.emitterPos)
        {
            case ParticleSystemInfoScript.EmitterPos.Top: {
                    pos = param.getAreaCenter() / 2 + param.getAreaConcentric() + param.getDirVector().y + param.getAreaOther() / 2.0f;
                    area = param.getAreaOther();
                }
                break;

            case ParticleSystemInfoScript.EmitterPos.Middle:
                {
                    pos = 0;
                    area = param.getAreaCenter();
                }
                break;

            case ParticleSystemInfoScript.EmitterPos.Bottom:
                {
                    pos = -(param.getAreaCenter() / 2 + param.getAreaConcentric() + param.getDirVector().y + param.getAreaOther() / 2.0f);
                    area = param.getAreaOther();
                }
                break;
        }

        CalculateEmitterShape(emData.emitter, area, pos);
    }

    private void CalculateEmitterShape(GameObject psObject, float area, float pos)
    {
        Vector2 origPos = psObject.transform.position;
        psObject.transform.position = new Vector2(origPos.x, pos);
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule sh = ps.shape;
        sh.radius = area / 2;
    }
}
