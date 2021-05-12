using System;

namespace Impact
{
    public class IParticle
    {
        private IVector3 position;
        private IVector3 velocity;
        private IVector3 acceleration;
        private IVector3 forceAccum;
        private double inverseMass;
        private double damping;
        private bool isDead;

        public double Mass
        {
            get { return InverseMass == 0 ? double.MaxValue : 1.0 / InverseMass; }
            set { InverseMass = 1.0 / Mass; }
        }
        public IVector3 Position { get => position; set => position = value; }
        public IVector3 Velocity { get => velocity; set => velocity = value; }
        public IVector3 Acceleration { get => acceleration; set => acceleration = value; }
        public IVector3 ForceAccum { get => forceAccum; set => forceAccum = value; }
        public double InverseMass { get => inverseMass; set => inverseMass = value; }
        public double Damping { get => damping; set => damping = value; }
        public bool IsDead { get => isDead; set => isDead = value; }

        public IParticle()
        {
            position = new IVector3();
            velocity = new IVector3();
            acceleration = new IVector3();
            forceAccum = new IVector3();
            inverseMass = 0;
            damping = 0.9;
            isDead = false;
        }

        public IParticle(double mass)
        {
            position = new IVector3();
            velocity = new IVector3();
            acceleration = new IVector3();
            forceAccum = new IVector3();
            inverseMass = 1.0 / mass;
            damping = 0.3;
            isDead = false;
        }

        public IParticle(double mass, IVector3 position)
        {
            this.position = position;
            velocity = new IVector3();
            acceleration = new IVector3();
            forceAccum = new IVector3();
            inverseMass = 1.0 / mass;
            damping = 1;
            isDead = false;
        }


        /// <summary>
        /// Clears the accumulated force of the particle.
        /// </summary>
        public void ClearAccumulator()
        {
            ForceAccum.Clear();
        }

        /// <summary>
        /// Adds a force to the particle.
        /// </summary>
        /// <param name="force">The force that should be added</param>
        public void AddForce(IVector3 force)
        {
            ForceAccum += force;
        }

        /// <summary>
        /// Calculate the integration of the particle in the specified time frame.
        /// </summary>
        /// <param name="duration">The time frame</param>
        public void Integrate(double duration)
        {
            if (IsDead | InverseMass <= 0) return;

            Position.AddScaledVector(Velocity, duration);

            IVector3 resultingAccel = new IVector3(Acceleration);
            resultingAccel.AddScaledVector(ForceAccum, InverseMass);

            Velocity.AddScaledVector(resultingAccel, duration);
            Velocity *= Math.Pow(Damping, duration);

            ClearAccumulator();
        }
    }
}