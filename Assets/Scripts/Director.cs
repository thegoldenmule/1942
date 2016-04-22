using Ninject;
using Space.Client;
using UnityEngine;

namespace Space
{
    /// <summary>
    /// Director acts as the main IOC container for the game. It holds and
    /// updates the core objects of the game.
    /// </summary>
    public class Director
    {
        /// <summary>
        /// IOC kernel.
        /// </summary>
        private static readonly StandardKernel _kernel = new StandardKernel(
            new NinjectSettings
            {
                LoadExtensions = false,
                InjectNonPublic = true,
                UseReflectionBasedInjection = true
            });

        /// <summary>
        /// Dependencies.
        /// </summary>
        private GameStateController _states;
        private InputController _input;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Director()
        {
            _kernel.Load(new ClientModule());
        }

        /// <summary>
        /// Called to start the game.
        /// </summary>
        public void Start()
        {
            _states = _kernel.Get<GameStateController>();
            _states.State = _states.Combat;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public void Update(float dt)
        {
            _states.DeltaUpdate(dt);
        }

        /// <summary>
        /// Called every frame after Update().
        /// </summary>
        public void LateUpdate()
        {
            
        }

        /// <summary>
        /// Called when application quits.
        /// </summary>
        public void OnApplicationQuit()
        {
            
        }

        /// <summary>
        /// Calls Ninject to inject an object.
        /// </summary>
        /// <param name="object"></param>
        public static void Inject(object @object)
        {
            _kernel.Inject(@object);
        }
    }
}