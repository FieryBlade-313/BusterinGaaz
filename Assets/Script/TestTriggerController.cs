using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerController : MonoBehaviour
{
    private void OnParticleTrigger()
    {
        
        ParticleSystem ps = GetComponent<ParticleSystem>();
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.velocity = new Vector3(0, 0, 0) * p.velocity.magnitude;
            p.startColor = new Color32(255, 0, 0, 255);

            enter[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

    }
}
