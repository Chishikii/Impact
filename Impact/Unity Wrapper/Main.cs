using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Particle
    public Transform particleTransform;
    public PhysicsParticle unityParticle;
    public Impact.IParticle particle;

    public Vector3 velocity;

    // World
    public ParticleWorld unityWorld;

    // ForceGenerator
    public Impact.IParticleGravity iGravityForceGen;
    public Impact.IParticleBuoyancy iBuoyancyForceGen;
    public Impact.IParticleDrag iDragForceGen;

    // PhysicsEngine
    public PhysicsEngine unityEngine;

    private void Start()
    {
        // Create particle
        particle = new Impact.IParticle(500, new Impact.IVector3(Converter.ConvertVector(particleTransform.position)));
        unityParticle = new PhysicsParticle(particleTransform, particle);

        // Assign particle to world
        unityWorld = new ParticleWorld();
        unityWorld.AddParticle(unityParticle);
        
        // Create ForceGenerators and assign them to impact world registry with particle
        // Gravity
        iGravityForceGen = new Impact.IParticleGravity(new Impact.IVector3(0, -9.82, 0));
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iGravityForceGen);
        // Buoyancy
        iBuoyancyForceGen = new Impact.IParticleBuoyancy(1, 1, 0);
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iBuoyancyForceGen);
        // Drag
        iDragForceGen = new Impact.IParticleDrag();
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iDragForceGen);

        // Create Engine and assign unity world to it
        unityEngine = new PhysicsEngine(unityWorld);

        // Debug
        StartCoroutine(DebugLog(10));
    }

    private void LateUpdate()
    {
        unityEngine.Tick(Time.deltaTime);
        velocity = Converter.ConvertVector(particle.Velocity);
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
