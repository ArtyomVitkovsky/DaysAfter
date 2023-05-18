using Modules.Game.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Main.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputService;
        [SerializeField] private MouseInput mouseInputService;
        
        public override void InstallBindings()
        {
            BindInputService();

            BindMouseInput();
        }
        
        private void BindInputService()
        {
            Container
                .Bind<InputService>()
                .FromInstance(inputService)
                .AsSingle();
        }
        
        private void BindMouseInput()
        {
            Container
                .Bind<MouseInput>()
                .FromInstance(mouseInputService)
                .AsSingle();
        }
    }
}