using System;

namespace Impact
{
    public class IVector3
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        /// <summary>
        /// Returns a vector with all components value equal 0.
        /// </summary>
        public static IVector3 Zero{ get => new IVector3(0, 0, 0); }

        public IVector3()
        {
            X = Y = Z = 0;
        }

        public IVector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public IVector3(IVector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        // Operators
        public static IVector3 operator +(IVector3 v) => v;

        public static IVector3 operator -(IVector3 v) =>
            new IVector3(-v.X, -v.Y, -v.Z);

        public static IVector3 operator +(IVector3 v1, IVector3 v2) =>
            new IVector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static IVector3 operator -(IVector3 v1, IVector3 v2) =>
            new IVector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        public static IVector3 operator *(IVector3 v1, double value) =>
            new IVector3(v1.X * value, v1.Y * value, v1.Z * value);

        public static bool operator ==(IVector3 v1, IVector3 v2) =>
            v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        public static bool operator !=(IVector3 v1, IVector3 v2) =>
            !(v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public double SquaredMagnitude()
        {
            return X * X + Y * Y + Z * Z;
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
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
        }

        /// <summary>
        /// Scalar / Dot product with another vector
        /// </summary>
        public double ScalarProduct(IVector3 v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        /// <summary>
        /// Scale and add a vector.
        /// </summary>
        public void AddScaledVector(IVector3 v, double s)
        {
            X += v.X * s;
            Y += v.Y * s;
            Z += v.Z * s;
        }

        /// <summary>
        /// Sets the vectors values back to zero.
        /// </summary>
        public void Clear()
        {
            X = Y = Z = 0;
        }

        #region Override Methods
        public override string ToString()
        {
            return $"({X:0.##}, {Y:0.##}, {Z:0.##})";
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
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        public static IVector3 CrossProduct(IVector3 v1, IVector3 v2)
        {
            return new IVector3(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X);
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
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static double SquaredMagnitude(IVector3 v)
        {
            return v.X * v.X + v.Y * v.Y + v.Z * v.Z;
        }
        #endregion
    }
}
