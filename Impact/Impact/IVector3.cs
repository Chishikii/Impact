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

        /// <summary>
        /// Cross product with another vector
        /// </summary>
        public IVector3 CrossProduct(IVector3 v)
        {
            return new IVector3(
                y * v.z - z * v.y,
                z * v.x - x * v.z,
                x * v.y - y * v.x);
        }

        /// <summary>
        /// Scalar / Dot product with another vector
        /// </summary>
        public double ScalarProduct(IVector3 v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        /// <summary>
        /// Scale and add a vector.
        /// </summary>
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

        #region Override Methods
        public override string ToString()
        {
            return $"({x:0.##}, {y:0.##}, {z:0.##})";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        
        #region Static Methods

        /// <summary>
        /// Scalar / Dot product of two vectors
        /// </summary>
        public static double ScalarProduct(IVector3 v1, IVector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        public static IVector3 CrossProduct(IVector3 v1, IVector3 v2)
        {
            return new IVector3(
                v1.y * v2.z - v1.z * v2.y,
                v1.z * v2.x - v1.x * v2.z,
                v1.x * v2.y - v1.y * v2.x);
        }

        /// <summary>
        /// Normalize a given vector
        /// </summary>
        public static IVector3 Normalize(IVector3 v)
        {
            return new IVector3(v * (1.0f / v.Magnitude()));
        }

        public static double Magnitude(IVector3 v)
        {
            return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }

        public static double SquaredMagnitude(IVector3 v)
        {
            return v.x * v.x + v.y * v.y + v.z * v.z;
        }
        #endregion
    }
}
