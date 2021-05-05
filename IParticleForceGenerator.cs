namespace Impact
{
    public abstract class IParticleForceGenerator
    {
        public abstract void UpdateForce(IParticle p, double duration); 
    }
}
