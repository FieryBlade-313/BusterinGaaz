using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderSetter : MonoBehaviour
{
    public ParticleDirectionController pd1;
    public ParticleDirectionController pd2;

    public void InitializeParticleDirection()
    {
        pd1.Initialize();
        pd2.Initialize();
    }

    public void SetParticleDirection()
    {
        pd1.SetTriggerDimension();
        pd2.SetTriggerDimension();
    }
}
