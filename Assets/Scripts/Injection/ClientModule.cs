using Ninject.Modules;
using UnityEngine;

namespace Space.Client
{
    public class ClientModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GameStateController>().ToProvider(new HierarchyResolver<GameStateController>(Tags.Controllers)).InSingletonScope();
            Bind<InputController>().ToProvider(new HierarchyResolver<InputController>(Tags.Controllers)).InSingletonScope();
            Bind<PoolManager>().ToProvider(new HierarchyResolver<PoolManager>(Tags.Controllers)).InSingletonScope();
            Bind<CameraController>().ToProvider(new HierarchyResolver<CameraController>(Tags.MainCamera)).InSingletonScope();
            Bind<MapController>().ToProvider(new HierarchyResolver<MapController>(Tags.Controllers)).InSingletonScope();
            Bind<Camera>().ToConstant(Camera.main).InSingletonScope();

            Bind<EntityManager>().To<EntityManager>().InSingletonScope();
        }
    }
}