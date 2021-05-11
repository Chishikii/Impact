namespace Impact
{
    public class IPhysicsEngineModule
    {
        private bool enabled = true;

        public bool IsEnabled { get => enabled;}

        public virtual IComputationInterface GetComputationInterface() { return null; }
        public virtual void Enable(bool enabled) { this.enabled = enabled; }
    }
}