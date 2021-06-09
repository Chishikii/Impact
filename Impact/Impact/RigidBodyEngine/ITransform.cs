namespace Impact
{
    /// <summary>
    /// Position and rotation of an object.
    /// </summary>
    class ITransform
    {
        private IVector3 position;
        private IQuaternion rotation;

        public ITransform()
        {
            position = new IVector3();
            rotation = new IQuaternion();
        }

        /// <summary>
        /// Creates a new transform
        /// </summary>
        /// <param name="position">initial position</param>
        /// <param name="rotation">inital rotation</param>
        public ITransform(IVector3 position, IQuaternion rotation)
        {
            this.rotation = rotation;
            this.position = position;
        }

        /// <summary>
        /// Moves the transform in the direction and distance of <paramref name="translation"/>
        /// </summary>
        public void Translate(IVector3 translation)
        {
            position += translation;
        }
        /// <summary>
        /// Moves the transform in the direction and distance of <paramref name="x"/> ,<paramref name="y"/> and <paramref name="z"/> 
        /// </summary>
        public void Translate(double x, double y, double z)
        {
            position.x += x;
            position.y += y;
            position.z += z;
        }
    }
}