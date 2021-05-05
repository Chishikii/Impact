using System.Collections.Generic;

namespace Impact
{
    public class IParticleWorld
    {
        public List<IParticle> particles;

        public void AddParticle(IParticle p)
        {
            particles.Add(p);
        }

        public void RemoveParticle(IParticle p)
        {
            particles.Remove(p);
        }

        public void Integrate(double duration)
        {
            foreach(IParticle p in particles)
            {
                p.Integrate(duration);
            }
        }
    }
}
