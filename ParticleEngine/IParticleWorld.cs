using System.Collections.Generic;

namespace Impact
{
    public class IParticleWorld : IPhysicsEngineModule
    {
        private List<IParticle> particles;
        private IParticleForceRegistry registry;
        private IParticleEngine computationInterface;

        public IParticleEngine ComputationInterface { get => computationInterface; set => computationInterface = value; }
        public IParticleForceRegistry Registry { get => registry; set => registry = value; }
        public List<IParticle> Particles { get => particles; set => particles = value; }

        public IParticleWorld()
        {
            particles = new List<IParticle>();
            registry = new IParticleForceRegistry();
            computationInterface = new IParticleEngine(this);
        }

        /// <summary>
        /// Adds a particle to the particle world.
        /// </summary>
        /// <param name="p"></param>
        public void AddParticle(IParticle p)
        {
            particles.Add(p);
        }

        /// <summary>
        /// Removes a particle form the particle world.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool RemoveParticle(IParticle p)
        {
            return particles.Remove(p);
        }

        /// <summary>
        /// Calls the integrate function on all of the particles contained in this world.
        /// </summary>
        /// <param name="duration"></param>
        public void Integrate(double duration)
        {
            foreach (IParticle p in particles)
            {
                p.Integrate(duration);
            }
        }

        public override IComputationInterface GetComputationInterface()
        {
            return computationInterface;
        }
    }
}
