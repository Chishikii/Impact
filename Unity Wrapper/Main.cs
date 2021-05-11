﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Particle
    public Transform particleTransform;
    public PhysicsParticle unityParticle;

    // World
    public ParticleWorld unityWorld;

    // ForceGenerator
    public Impact.IParticleGravity iGravityForceGen;

    // PhysicsEngine
    public PhysicsEngine unityEngine;

    private void Start()
    {
        // Create particle
        unityParticle = new PhysicsParticle(particleTransform, new Impact.IParticle(1.0));

        // Assign particle to world
        unityWorld = new ParticleWorld();
        unityWorld.AddParticle(unityParticle);

        // Create ForceGenerator and assign to impact world registry with particle
        iGravityForceGen = new Impact.IParticleGravity(new Impact.IVector3(0, -1, 0));
        unityWorld.iParticleWorld.Registry.Add(unityParticle.iParticle, iGravityForceGen);

        // Create Engine and assign unity world to it
        unityEngine = new PhysicsEngine(unityWorld);
    }

    private void Update()
    {
        unityEngine.Tick(Time.deltaTime);
    }
}