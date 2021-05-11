using System;

namespace Impact
{
    public class IVector3
    {
        public double x;
        public double y;
        public double z;

        public IVector3()
        {
            x = y = z = 0;
        }

        public IVector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public IVector3(IVector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        // Operators
        public static IVector3 operator +(IVector3 v) => v;

        public static IVector3 operator -(IVector3 v) =>
            new IVector3(-v.x, -v.y, -v.z);

        public static IVector3 operator +(IVector3 v1, IVector3 v2) =>
            new IVector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

        public static IVector3 operator -(IVector3 v1, IVector3 v2) =>
            new IVector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        public static IVector3 operator *(IVector3 v1, double value) =>
            new IVector3(v1.x * value, v1.y * value, v1.z * value);

        public static bool operator ==(IVector3 v1, IVector3 v2) =>
            v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;

        public static bool operator !=(IVector3 v1, IVector3 v2) =>
            !(v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);

        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public double SquaredMagnitude()
        {
            return x * x + y * y + z * z;
        }

        public IVector3 Normalized()
        {
            return new IVector3(this * (1.0f / Magnitude()));
        }

        public IVector3 CrossProduct(IVector3 v)
        {
            return new IVector3(y * v.z - z * v.y,
                z * v.x - x * v.z,
                x * v.y - y * v.x);
        }

        /// <summary>
        /// Scale and add a vector.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="s"></param>
        public void AddScaledVector(IVector3 v, double s)
        {
            x += v.x * s;
            y += v.y * s;
            z += v.z * s;
        }

        /// <summary>
        /// Sets the vectors values back to zero.
        /// </summary>
        public void Clear()
        {
            x = y = z = 0;
        }
    }
}
