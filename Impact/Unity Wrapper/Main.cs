using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Particle
    public Transform particleTransform;
    public PhysicsParticle unityParticle;
    public Impact.IParticle particle;

    // World
    public ParticleWorld unityWorld;

    // ForceGenerator
    public Impact.IParticleGravity iGravityForceGen;
    public Impact.IParticleBuoyancy iBuoyancyForceGen;

    // PhysicsEngine
    public PhysicsEngine unityEngine;

    private void Start()
    {
        // Create particle
        particle = new Impact.IParticle(1.0, new Impact.IVector3(Converter.ConvertVector(particleTransform.position)));
        unityParticle = new PhysicsParticle(particleTransform, particle);

        // Assign particle to world
        unityWorld = new ParticleWorld();
        unityWorld.AddParticle(unityParticle);

        // Create ForceGenerator and assign to impact world registry with particle
        // Gravity
        iGravityForceGen = new Impact.IParticleGravity(new Impact.IVector3(0, -9.82, 0));
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iGravityForceGen);
        // Buoyancy
        iBuoyancyForceGen = new Impact.IParticleBuoyancy(1, 4 * Mathf.PI / 3, 0);
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iBuoyancyForceGen);

        // Create Engine and assign unity world to it
        unityEngine = new PhysicsEngine(unityWorld);

        // Debug
        StartCoroutine(DebugLog(10));
    }

    private void Update()
    {
        unityEngine.Tick(Time.deltaTime);
    }

    IEnumerator DebugLog(float waitTime)
    {
        while (true)
        {
            Debug.Log("Velocity:" + unityParticle.iParticle.Velocity);
            Debug.Log("Position:" + unityParticle.iParticle.Position);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
