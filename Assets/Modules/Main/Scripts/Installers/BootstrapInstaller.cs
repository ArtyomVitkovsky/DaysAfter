using UnityEngine;
using Zenject;

namespace Modules.Main.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;
        
        public override void InstallBindings()
        {
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            var sceneLoaderInstance = Container
                .InstantiatePrefabForComponent<SceneLoader>(sceneLoader);

            Container
                .Bind<SceneLoader>()
                .FromInstance(sceneLoaderInstance)
                .AsSingle();
        }
    }
}