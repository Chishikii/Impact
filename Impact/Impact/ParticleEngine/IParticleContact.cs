using System;

namespace Impact
{
    /// <summary>
    /// Holds contact information of two particles.
    /// </summary>
    class IParticleContact
    {
        IParticle[] particles;
        IVector3 contactNormal;
        double restitution;
        double penetration;
    }
}