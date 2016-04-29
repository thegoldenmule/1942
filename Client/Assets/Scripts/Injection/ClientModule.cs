using Ninject.Modules;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Bindings for client.
    /// </summary>
    public class ClientModule : NinjectModule
    {
        /// <summary>
        /// Loads bindings.
        /// </summary>
        public override void Load()
        {
            Bind<GameStateController>().ToProvider(new HierarchyResolver<GameStateController>(Tags.Controllers)).InSingletonScope();
            Bind<InputController>().ToProvider(new HierarchyResolver<InputController>(Tags.Controllers)).InSingletonScope();
            Bind<PoolManager>().ToProvider(new HierarchyResolver<PoolManager>(Tags.Controllers)).InSingletonScope();
            Bind<CameraController>().ToProvider(new HierarchyResolver<CameraController>(Tags.MainCamera)).InSingletonScope();
            Bind<MapController>().ToProvider(new HierarchyResolver<MapController>(Tags.Controllers)).InSingletonScope();
            Bind<SpawnerManager>().ToProvider(new HierarchyResolver<SpawnerManager>(Tags.Spawners)).InSingletonScope();
            Bind<UIController>().ToProvider(new HierarchyResolver<UIController>(Tags.Controllers)).InSingletonScope();
            Bind<Camera>().ToConstant(Camera.main).InSingletonScope();
            Bind<ProjectileManager>().To<ProjectileManager>().InSingletonScope();

            Bind<EntityManager>().To<EntityManager>().InSingletonScope();
        }
    }
}