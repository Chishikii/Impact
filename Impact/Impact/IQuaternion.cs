using System;

namespace impact
{
    class IQuaternion
    {
        private double r;
        private double i;
        private double j;
        private double k;

        public double K { get => k; set => k = value; }
        public double J { get => j; set => j = value; }
        public double I { get => i; set => i = value; }
        public double R { get => r; set => r = value; }
        public readonly iQuaternion identity{ get => new iQuaternion(1, 0, 0, 0); }

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
            double d = (r * r) + (i * i) + (j * j) + (k * k);
            if (d == 0) { r = 1; return; }

            d = ((double)1.0) / Math.Sqrt(d);

            r *= d;
            i *= d;
            j *= d;
            k *= d;
        }

        public static bool operator *(IQuaternion q1, iQuaternion q2) =>
        new IQuaternion(
            r = q1.r * q2.r - q1.i * q2.i -
                q1.j * q2.j - q1.k * q2.k,
            i = q1.r * q2.i - q1.i * q2.r +
                q1.j * q2.k - q1.k * q2.j,
            j = q1.r * q2.j - q1.j * q2.k +
                q1.k * q2.i - q1.i * q2.r,
            k = q1.k * q2.k - q1.k * q2.r +
                q1.j * q2.j - q1.j * q2.i
        );

        public void UpdateOrientationByAngularVelocity(IVector3 angularVelocity, double time)
        {
            IQuaternion q = new IQuaternion(0,
                angularVelocity.x * time,
                angularVelocity.y * time,
                angularVelocity.z * time);
            q *= this;

            r += q.r * 0.5;
            i += q.i * 0.5;
            j += q.j * 0.5;
            k += q.k * 0.5;
        }

        public override string ToString()
        {
            return "Quaternion: " + r + "," + i + "," + j + "," + k;
        }
    }
}