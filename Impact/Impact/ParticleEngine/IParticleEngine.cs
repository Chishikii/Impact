namespace Impact
{
    /// <summary>
    /// ParticleEngine implementation of IComputationInterfaces used for particle worlds.
    /// </summary>
    public class IParticleEngine : IComputationInterface
    {
        private IParticleWorld particleWorld;

        /// <summary>
        /// Particle world used for calculations.
        /// </summary>
        public IParticleWorld ParticleWorld { get => particleWorld; set => particleWorld = value; }

        /// <summary>
        /// The ParticleEngine constructor.
        /// </summary>
        /// <param name="particleWorld">Particle world used for calculations.</param>
        public IParticleEngine(IParticleWorld particleWorld)
        {
            this.particleWorld = particleWorld;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnBegin()
        {

        }

        /// <summary>
        /// Does a step in physics calculation and apllies new forces.
        /// </summary>
        public override void Step()
        {
            particleWorld.Registry.UpdateForces();
        }

        /// <summary>
        /// Integrates all particles in the particle world.
        /// </summary>
        /// <param name="timeDelta">Time step for this update.</param>
        public override void Integrate(float timeDelta)
        {
            particleWorld.Integrate(timeDelta);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnEnd()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {

        }

    }
}