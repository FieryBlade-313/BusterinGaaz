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

    public emitterData getEmitter1()
    {
        return emitter1;
    }
}
