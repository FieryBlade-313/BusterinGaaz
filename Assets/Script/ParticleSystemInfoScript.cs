using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemInfoScript : MonoBehaviour
{ 
    public enum EmitterPos { Top, Middle, Bottom };

    [System.Serializable]
    public struct emitterData
    {
        public GameObject emitter;
        public EmitterPos emitterPos; 
    }

    public emitterData emitter1;
    public emitterData emitter2;
    public emitterData emitter3;

    public emitterData getEmitter1()
    {
        return emitter1;
    }

    public void SetCollider1(PolygonCollider2D polyCollider)
    {
        emitter1.emitter.GetComponent<ParticleSystem>().trigger.SetCollider(0, polyCollider);
    }

    public emitterData getEmitter2()
    {
        return emitter2;
    }

    public void SetCollider2(PolygonCollider2D polyCollider)
    {
        emitter2.emitter.GetComponent<ParticleSystem>().trigger.SetCollider(0, polyCollider);
    }

    public emitterData getEmitter3()
    {
        return emitter3;
    }

    public void SetCollider3(PolygonCollider2D polyCollider)
    {
        emitter3.emitter.GetComponent<ParticleSystem>().trigger.SetCollider(0, polyCollider);
    }
}
