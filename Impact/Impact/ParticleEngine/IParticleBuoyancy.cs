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
            liquidDensity = 1000;
            gravity = 9.81;
        }

        public override void UpdateForce(IParticle p)
        {
            double depth = p.Position.y;
            double halfMaxDepth = maxDepth / 2;

            // Above water
            if (depth >= liquidHeight + halfMaxDepth) return;

            double verticalForce = liquidDensity * volume * gravity;
            IVector3 force = new IVector3();

            // Under water completely
            if (depth <= liquidHeight - halfMaxDepth)
            {
                force.y = verticalForce;
                p.AddForce(force);
                return;
            }

            // Partly under water
            double distanceSubmerged = liquidHeight - depth + halfMaxDepth;
            force.y = verticalForce * distanceSubmerged / maxDepth;
            p.AddForce(force);
        }
    }
}
