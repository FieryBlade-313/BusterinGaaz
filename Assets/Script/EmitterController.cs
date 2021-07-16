using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour
{

    public GameObject emitterFuel;
    public int flowRate = 10;
    [SerializeField]
    private float particleSeperation = 0.05f;
    [SerializeField]
    private float emitForce = 10f;
    private int maxCount = 2000;
    private int count = 0;

    private void FixedUpdate()
    {
        SpawnEmitterPerFrame();
    }

    private void SpawnEmitterPerFrame()
    {
        for (int i = 0; i < flowRate; i++)
        {
            if (count < maxCount)
            {
                SpawnEmitterFuelParticle(new Vector2(transform.position.x, transform.position.y - flowRate * particleSeperation / 2.0f + i * particleSeperation));
                count++;
            }
        }
    }

    private void SpawnEmitterFuelParticle(Vector2 pos)
    {
        GameObject fuelParticle = Instantiate(emitterFuel, pos, Quaternion.identity);
        fuelParticle.GetComponent<Rigidbody2D>().AddForce(transform.right * emitForce);
    }
}
