using System.Collections;
using System.Collections.Generic;
using Impact;
using UnityEngine;

public class ParticleWorld
{
    public List<PhysicsParticle> physicsParticles;
    public IParticleWorld iParticleWorld;
    public IComputationInterface ci;


    public ParticleWorld()
    {
        physicsParticles = new List<PhysicsParticle>();
        iParticleWorld = new IParticleWorld();
        ci = new IParticleEngine(iParticleWorld);
    }

    public ParticleWorld(PhysicsParticle particle)
    {
        // Particles in unity
        physicsParticles = new List<PhysicsParticle> { particle };

        // Particles in impact
        iParticleWorld = new IParticleWorld();
        iParticleWorld.AddParticle(particle.iParticle);

        // Physics engine used by this module (world)
        ci = new IParticleEngine(iParticleWorld);
    }

    public void AddParticle(PhysicsParticle particle)
    {
        // Add to list of Unity particles to update position
        physicsParticles.Add(particle);
        // Add particle to Impact World for computation
        iParticleWorld.AddParticle(particle.iParticle);

    }

    public void UpdateParticleWorld()
    {
        foreach (PhysicsParticle physicsParticle in physicsParticles)
        {
            physicsParticle.UpdateParticle();
        }
    }
}