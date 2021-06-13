namespace Impact
{
    public class IParticleContactResolver
    {
        private int maxIterations;
        private int usedIterations;
        
        public int MaxIterations { get => maxIterations; set => maxIterations = value; }

        public IParticleContactResolver(int iterations = 0)
        {
            usedIterations = 0;
        }

        void ResolveContacts()
        {
            
        }
    }
}