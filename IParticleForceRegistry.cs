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

        public void UpdateForces(double duration)
        {
            foreach (IParticleForceRegistrationEntry pfe in registry)
            {
                pfe.forceGenerator.UpdateForce(pfe.particle, duration);
            }
        }
    }
}

