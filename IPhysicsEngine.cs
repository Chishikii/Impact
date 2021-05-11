using System.Collections.Generic;

namespace Impact
{
    /// <summary>
    /// The IPhysicsEngine is the main Engine it manages all PhysicEngineModules
    /// </summary>
    public class IPhysicsEngine
    {
        private Dictionary<string, IPhysicsEngineModule> modules;
        private bool paused = false;

        public bool IsPaused { get => paused; }
        public void Pause() { paused = true; }
        public void Resume() { paused = false; }


        public IPhysicsEngine()
        {
            modules = new Dictionary<string, IPhysicsEngineModule>();
        }

        /// <summary>
        /// Update all enabled physics modules
        /// </summary>
        /// <param name="timeDelta"></param>
        public void Tick(float timeDelta)
        {
            if (paused) return;

            OnBegin();
            Step();
            Integrate(timeDelta);
            OnEnd();
        }

        /// <summary>
        /// Try to find registred module
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The found module or null if no is found</returns>
        public IPhysicsEngineModule FindModule(string key)
        {
            modules.TryGetValue(key, out IPhysicsEngineModule value);
            return value;
        }

        public bool IsModuleRegistered(string key)
        {
            return modules.ContainsKey(key);
        }

        public IPhysicsEngineModule RegisterModule(IPhysicsEngineModule module, string key)
        {
            var foundModule = FindModule(key);
            if (foundModule != null) return foundModule;

            modules.Add(key, module);
            return module;
        }

        /// <summary>
        /// Trys to unregister the module specified
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The unregistered module or null</returns>
        public IPhysicsEngineModule UnregisterModule(string key)
        {
            var foundModule = FindModule(key);
            if (foundModule == null) return null;

            modules.Remove(key);
            return foundModule;
        }

        /// <summary>
        /// Calls OnBegin function in every Module
        /// </summary>
        private void OnBegin()
        {
            Dictionary<string, IPhysicsEngineModule>.ValueCollection physicsModules = modules.Values;
            foreach (IPhysicsEngineModule module in physicsModules)
            {
                if (module.IsEnabled)
                {
                    module.GetComputationInterface().OnBegin();
                }
            }
        }

        /// <summary>
        /// Calls OnEnd function in every Module
        /// </summary>
        private void OnEnd()
        {
            Dictionary<string, IPhysicsEngineModule>.ValueCollection physicsModules = modules.Values;
            foreach (IPhysicsEngineModule module in physicsModules)
            {
                if (module.IsEnabled)
                {
                    module.GetComputationInterface().OnEnd();
                }
            }
        }

        /// <summary>
        /// Calls Step function in every Module
        /// </summary>
        private void Step()
        {
            Dictionary<string, IPhysicsEngineModule>.ValueCollection physicsModules = modules.Values;
            foreach (IPhysicsEngineModule module in physicsModules)
            {
                UnityEngine.Debug.Log(module.IsEnabled);
                if (module.IsEnabled)
                {
                    module.GetComputationInterface().Step();
                }
            }
        }

        /// <summary>
        /// Calls Integrate function in every Module
        /// </summary>
        private void Integrate(float timeDelta)
        {
            Dictionary<string, IPhysicsEngineModule>.ValueCollection physicsModules = modules.Values;
            foreach (IPhysicsEngineModule module in physicsModules)
            {
                if (module.IsEnabled)
                {
                    module.GetComputationInterface().Integrate(timeDelta);
                }
            }
        }
    }
}