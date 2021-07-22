using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleDirectionController targetControllerScript = null;
    private void OnParticleTrigger()
    {
        if(targetControllerScript != null)
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enter[i];
                p.velocity = targetControllerScript.getDirection() * p.velocity.magnitude;
                enter[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        }
    }
}
