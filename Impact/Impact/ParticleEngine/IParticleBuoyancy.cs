namespace Impact
{
    public class IParticleBuoyancy : IParticleForceGenerator
    {
        protected double maxDepth;
        protected double volume;

        protected double liquidHeight;
        protected double liquidDensity;

        protected double gravity;

        public IParticleBuoyancy(double maxDepth, double volume, double liquidHeight, double liquidDensity, double gravity)
        {
            this.maxDepth = maxDepth;
            this.volume = volume;
            this.liquidHeight = liquidHeight;
            this.liquidDensity = liquidDensity;
            this.gravity = gravity;
        }

        public IParticleBuoyancy(double maxDepth, double volume, double liquidHeight)
        {
            this.maxDepth = maxDepth;
            this.volume = volume;
            this.liquidHeight = liquidHeight;
            liquidDensity = 1000.0;
            gravity = 9.81;
        }

        public override void UpdateForce(IParticle p)
        {
            double depth = p.Position.Y;
            double halfMaxDepth = maxDepth / 2;

            // Above water
            if (depth >= liquidHeight + halfMaxDepth) return;

            double verticalForce = liquidDensity * volume * gravity;
            IVector3 force = new IVector3();

            // Under water completely
            if (depth <= liquidHeight - halfMaxDepth)
            {
                UnityEngine.Debug.LogWarning("under water");
                force.Y = verticalForce;
                p.AddForce(force);
                return;
            }

            // Partly under water
            UnityEngine.Debug.LogWarning("partly under water");
            double distanceSubmerged = liquidHeight - depth + halfMaxDepth;
            force.Y = verticalForce * (distanceSubmerged / maxDepth);
            
            p.AddForce(force);
        }
    }
}
