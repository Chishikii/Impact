namespace Impact
{
    public class IParticleDrag : IParticleForceGenerator
    {
        protected double circumfrenceArea;
        protected double dragCoefficent;
        protected double mediumDensity;

        public IParticleDrag()
        {
            circumfrenceArea = 4;
            dragCoefficent = 0.8;
            // Air
            // mediumDensity = 1.225;
            mediumDensity = 200;
        }

        public IParticleDrag(double circumfrenceArea, double dragCoefficent, double mediumDensity)
        {
            this.circumfrenceArea = circumfrenceArea;
            this.dragCoefficent = dragCoefficent;
            this.mediumDensity = mediumDensity;
        }

        public override void UpdateForce(IParticle p)
        {
            mediumDensity = 10;
            if (p.Position.y <= 0) mediumDensity = 900;
       
            IVector3 force = p.Velocity;
            double magnitude = force.Magnitude();
            if (magnitude == 0) return;

            double drag = 0.5 * circumfrenceArea * dragCoefficent * mediumDensity * magnitude * magnitude;
            force = force.Normalized();
            force *= -drag;

            p.AddForce(force);
        }
    }
}