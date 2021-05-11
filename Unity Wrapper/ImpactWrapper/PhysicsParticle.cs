using System.Collections;
using System.Collections.Generic;
using Impact;
using UnityEngine;

public class PhysicsParticle
{
    public Transform unityPosition;
    public IParticle iParticle;

    public PhysicsParticle(Transform unityPosition, IParticle particle)
    {
        this.unityPosition = unityPosition;
        this.iParticle = particle;
    }

    public void UpdateParticle()
    {
        Vector3 position = Converter.ConvertVector(iParticle.Position);
        unityPosition.position = position;
    }
}
