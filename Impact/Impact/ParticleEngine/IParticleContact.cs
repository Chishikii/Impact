using System;

namespace Impact
{
    /// <summary>
    /// Holds contact information of two particles.
    /// </summary>
    class IParticleContact
    {
        // TODO: Write custom tuple for particles.
        private IParticle[] particles = new IParticle[2];
        private IVector3[] particleMovement = new IVector3[2];
        private IVector3 contactNormal = new IVector3();
        private double restitution = 0;
        private double penetration = 0;
        
        public double TotalInverseMass
        {
            get
            {
                double totalInverseMass = Particles[0].InverseMass;
                if (Particles[1].HasFiniteMass) totalInverseMass += Particles[1].InverseMass;
                return totalInverseMass;
            }
        }
        public IParticle[] Particles { get => particles; set => particles = value; }
        public IVector3[] ParticleMovement { get => particleMovement; set => particleMovement = value; }
        public IVector3 ContactNormal { get => contactNormal; set => contactNormal = value; }
        public double Restitution { get => restitution; set => restitution = value; }
        public double Penetration { get => penetration; set => penetration = value; }

        /// <summary>
        /// Initialize the contact with two particles.
        /// </summary>
        /// <param name="first">first particle in the contact</param>
        /// <param name="second">second particle in the contact</param>
        public void Init(IParticle first, IParticle second)
        {
            Particles[1] = first;
            Particles[2] = second;
        }

        /// <summary>
        /// Resolve the velocity and interpenetration in the given time.
        /// </summary>
        public void Resolve(double duration)
        {
            ResolveVelocity(duration);
            ResolveInterpenetration(duration);
        }

        public void ResolveVelocity(double duration)
        {
            double originalSeperatingVelocity = SeperatingVelocity();

            // No movement in particlespp
            if (originalSeperatingVelocity > 0) return;

            // Both particles have infinite mass, nothing changes.
            if (!Particles[0].HasFiniteMass && !Particles[1].HasFiniteMass) return;

            double seperatingVelocity = originalSeperatingVelocity * Restitution;

            // Resting contacts
            IVector3 accelerationCausedVelocity = Particles[0].Acceleration;
            if (Particles[1].HasFiniteMass) accelerationCausedVelocity -= Particles[1].Acceleration;

            // How much of that in direction of contactNormal
            double accelerationCausedSeperationVelocity =
                IVector3.ScalarProduct(accelerationCausedVelocity, ContactNormal) * duration;

            // If a acceleration based collison velocity exists subtract it from seperationVelocity
            if (accelerationCausedSeperationVelocity < 0)
            {
                seperatingVelocity += accelerationCausedSeperationVelocity * Restitution;
                if (seperatingVelocity < 0) seperatingVelocity = 0;
            }

            // Total velocity
            double deltaVelocity = seperatingVelocity - originalSeperatingVelocity;

            // Impulse in direction of contactnormal
            double impulse = deltaVelocity / TotalInverseMass;
            IVector3 impulseNormal = ContactNormal * impulse;

            // Apply impulseNormal
            if (Particles[0].HasFiniteMass) Particles[0].Velocity += impulseNormal * Particles[0].InverseMass;
            if (Particles[1].HasFiniteMass) Particles[1].Velocity += impulseNormal * -Particles[1].InverseMass;
        }

        public void ResolveInterpenetration(double duration)
        {
            // No penetration to resolve or immovable object.
            if (Penetration <= 0) return;
            if (TotalInverseMass <= 0) return;
            
            // scale forces based on mass and penetration.
            IVector3 translationPerInverseMass = ContactNormal * (Penetration / TotalInverseMass);
            particleMovement[0] = translationPerInverseMass * particles[0].InverseMass;
            particleMovement[1] = particles[1].HasFiniteMass ?
                translationPerInverseMass * -particles[1].InverseMass :
                IVector3.Zero;

            // apply forces created by penetration.
            particles[0].Translate(ParticleMovement[0]);
            particles[1].Translate(ParticleMovement[1]);
        }

        public double SeperatingVelocity()
        {
            IVector3 relativeVelocity = Particles[0].Velocity;
            if (Particles[2].HasFiniteMass) relativeVelocity -= Particles[1].Velocity;
            return IVector3.ScalarProduct(relativeVelocity, ContactNormal);
        }
    }
}