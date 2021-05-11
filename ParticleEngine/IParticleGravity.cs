namespace Impact
{
    public class IParticleGravity : IParticleForceGenerator
    {
        protected IVector3 gravity;

        public IParticleGravity(IVector3 gravity)
        {
            this.gravity = gravity;
        }

        public override void UpdateForce(IParticle particle)
        {
            if (particle.InverseMass == 0) return;

            particle.AddForce(gravity * particle.Mass);
        }
    }
}