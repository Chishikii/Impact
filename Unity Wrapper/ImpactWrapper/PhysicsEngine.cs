using System.Collections;
using System.Collections.Generic;
using Impact;
using UnityEngine;

public class PhysicsEngine
{
    public IPhysicsEngine iPhysicsEngine;
    public ParticleWorld physicsParticleWorld;

    public PhysicsEngine(ParticleWorld world)
    {
        Init(world);
    }

    public void Init(ParticleWorld world)
    {
        physicsParticleWorld = world;
        iPhysicsEngine = new IPhysicsEngine();

        iPhysicsEngine.RegisterModule(physicsParticleWorld.iParticleWorld, "Particle");
        iPhysicsEngine.Resume();
    }

    public void Tick(float timeDelta)
    {
        // Calcuates changes in physics
        iPhysicsEngine.Tick(timeDelta);

        // Updates unitys position based on particles position and calculated changes
        physicsParticleWorld.UpdateParticleWorld();
    }
}
