using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private KeyboardInput keyboardInputPrefab;
        [SerializeField] private MouseInput mouseInputPrefab;
        public override void InstallBindings()
        {
            InputService inputServiceInstance;
            MouseInput mouseInputInstance;
            
            #if UNITY_EDITOR || !UNITY_ANDROID 
            inputServiceInstance = Container
                .InstantiatePrefabForComponent<InputService>(keyboardInputPrefab);

            mouseInputInstance = Container.InstantiatePrefabForComponent<MouseInput>(mouseInputPrefab);
            Container
                .Bind<MouseInput>()
                .FromInstance(mouseInputInstance)
                .AsSingle()
                .NonLazy();
            
            #endif
            
            Container
                .Bind<InputService>()
                .FromInstance(inputServiceInstance)
                .AsSingle()
                .NonLazy();
            
        }
    }
}