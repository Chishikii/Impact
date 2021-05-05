using System;

namespace Impact
{
    public class IParticle
    {
        public IVector3 position;
        public IVector3 velocity;
        public IVector3 acceleration;
        public IVector3 forceAccum;
        public double inverseMass;
        public double damping;
        public bool isDead;

        public double Mass
        {
            get { return inverseMass == 0 ? double.MaxValue : 1.0 / inverseMass; }
            set { inverseMass = 1.0 / Mass; }
        }
        public void ClearAccumulator()
        {
            forceAccum.Clear();
        }

        public void AddForce(IVector3 force)
        {
            forceAccum += force;
        }

        public virtual void Integrate(double duration)
        {
            if (isDead | inverseMass <= 0) return;

            position.AddScaledVector(velocity, duration);

            IVector3 resulting = acceleration;
            resulting.AddScaledVector(forceAccum, inverseMass);

            velocity.AddScaledVector(resulting, duration);
            velocity *= Math.Pow(damping, duration);

            ClearAccumulator();
        }
    }
}