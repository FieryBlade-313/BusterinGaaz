using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitterShapeModifier : MonoBehaviour
{
    Parameters param;
    ParticleSystemInfoScript psInfo;

    public float maxEmmision;

    private void Start()
    {
        param = GetComponent<Parameters>();
        psInfo = GetComponent<ParticleSystemInfoScript>();
    }

    public void SetEmittersShape()
    {
        ParticleSystemInfoScript.emitterData emitter1Data = psInfo.getEmitter1();
        ParticleSystemInfoScript.emitterData emitter2Data = psInfo.getEmitter2();
        ParticleSystemInfoScript.emitterData emitter3Data = psInfo.getEmitter3();

        ChangeShapeByEmitterType(emitter1Data);
        ChangeShapeByEmitterType(emitter2Data);
        ChangeShapeByEmitterType(emitter3Data);

    }

    public void ChangeShapeByEmitterType( ParticleSystemInfoScript.emitterData emData )
    {
        float pos = 0, area = 0, areaNrm = 0;

        switch(emData.emitterPos)
        {
            case ParticleSystemInfoScript.EmitterPos.Top: {
                    pos = param.getAreaCenter() / 2 + param.getAreaConcentric() + param.getDirVector().y + param.getAreaOther() / 2.0f;
                    area = param.getAreaOther();
                    areaNrm = (float)param.parameters.areaOther;
                }
                break;

            case ParticleSystemInfoScript.EmitterPos.Middle:
                {
                    pos = 0;
                    area = param.getAreaCenter();
                    areaNrm = (float)param.parameters.areaCenter;
                }
                break;

            case ParticleSystemInfoScript.EmitterPos.Bottom:
                {
                    pos = -(param.getAreaCenter() / 2 + param.getAreaConcentric() + param.getDirVector().y + param.getAreaOther() / 2.0f);
                    area = param.getAreaOther();
                    areaNrm = (float)param.parameters.areaOther;
                }
                break;
        }

        CalculateEmitterShape(emData.emitter, area, pos, areaNrm);
    }

    private void CalculateEmitterShape(GameObject psObject, float area, float pos, float areaNrm)
    {
        Vector2 origPos = psObject.transform.position;
        psObject.transform.position = new Vector2(origPos.x, pos);
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule sh = ps.shape;
        sh.radius = area / 2;
        ParticleSystem.EmissionModule em = ps.emission;
        em.rateOverTime = Mathf.Lerp(0, maxEmmision, areaNrm);
    }
}
