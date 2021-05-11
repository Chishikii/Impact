
namespace Impact
{
    /// <summary>
    /// Interface used by physics modules providing basic tasks
    /// </summary>
    public abstract class IComputationInterface
    {
        /// <summary>
        /// Called at the start of a physics step
        /// </summary>
        public abstract void OnBegin();

        /// <summary>
        /// Used to calculate changes
        /// </summary>
        public abstract void Step();

        /// <summary>
        /// Used to apply changes
        /// </summary>
        /// <param name="timeDelta">Time step of physics step</param>
        public abstract void Integrate(float timeDelta);

        /// <summary>
        /// Called at the end of a physics step
        /// </summary>
        public abstract void OnEnd();

        /// <summary>
        /// Resets the ComputationInterface to its start state
        /// </summary>
        public abstract void Reset();
    }
}
