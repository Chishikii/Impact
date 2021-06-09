using System;

namespace Impact
{
    class IQuaternion
    {
        private double r;
        private double i;
        private double j;
        private double k;

        protected double K { get => k; set => k = value; }
        protected double J { get => j; set => j = value; }
        protected double I { get => i; set => i = value; }
        protected double R { get => r; set => r = value; }

        public IQuaternion()
        {
            this.r = 1;
            this.i = this.j = this.k = 0;
        }

        public IQuaternion(double r, double i, double j, double k)
        {
            this.r = r;
            this.i = i;
            this.j = j;
            this.k = k;
        }

        public void Normalize()
        {
            double d = (R * R) + (I * I) + (J * J) + (K * K);
            if (d == 0) { r = 1; return; }

            d = ((double)1.0) / Math.Sqrt(d);

            R *= d;
            I *= d;
            J *= d;
            K *= d;
        }

        public static bool operator *(IQuaternion q1, IQuaternion q2) =>
        new IQuaternion(
            R = q1.R * q2.R - q1.I * q2.I -
                q1.J * q2.J - q1.K * q2.K,
            I = q1.R * q2.I - q1.I * q2.R +
                q1.J * q2.K - q1.K * q2.J,
            J = q1.R * q2.J - q1.J * q2.K +
                q1.K * q2.I - q1.I * q2.R,
            K = q1.K * q2.K - q1.K * q2.R +
                q1.J * q2.J - q1.J * q2.I
        );

        public void UpdateOrientationByAngularVelocity(IVector3 angularVelocity, double time)
        {
            IQuaternion q = new IQuaternion(0,
                angularVelocity.x * time,
                angularVelocity.y * time,
                angularVelocity.z * time);
            q *= this;

            R += q.R * 0.5;
            I += q.I * 0.5;
            J += q.J * 0.5;
            K += q.K * 0.5;
        }

        public override string ToString()
        {
            return "Quaternion: " + R + "," + I + "," + J + "," + K;
        }
    }
}