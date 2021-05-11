using System.Collections.Generic;

namespace Impact
{
    public class IParticleForceRegistry
    {
        private struct IParticleForceRegistrationEntry
        {
            public IParticleForceRegistrationEntry(IParticle p, IParticleForceGenerator fg)
            {
                particle = p;
                forceGenerator = fg;
            }

            public IParticle particle;
            public IParticleForceGenerator forceGenerator;
        }

        private readonly List<IParticleForceRegistrationEntry> registry;

        public IParticleForceRegistry()
        {
            registry = new List<IParticleForceRegistrationEntry>();
        }

        public void Add(IParticle p, IParticleForceGenerator fg)
        {
            IParticleForceRegistrationEntry registration = new IParticleForceRegistrationEntry(p, fg);
            registry.Add(registration);
        }

        public void Remove(IParticle p, IParticleForceGenerator fg)
        {
            foreach (IParticleForceRegistrationEntry pfe in registry)
            {
                if (pfe.particle == p && pfe.forceGenerator == fg) registry.Remove(pfe);
            }
        }

        public void Clear()
        {
            registry.Clear();
        }

        /// <summary>
        /// Applies the forces on the particle supplied by the force generator for each particle.
        /// </summary>
        public void UpdateForces()
        {
            foreach (IParticleForceRegistrationEntry pfe in registry)
            {
                pfe.forceGenerator.UpdateForce(pfe.particle);
            }
        }
    }
}

