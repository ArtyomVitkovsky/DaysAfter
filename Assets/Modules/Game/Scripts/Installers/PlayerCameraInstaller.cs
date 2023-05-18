using Modules.Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class PlayerCameraInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCamera playerCameraPrefab;
        
        public override void InstallBindings()
        {
            var playerCameraInstance = Container
                .InstantiatePrefabForComponent<PlayerCamera>(playerCameraPrefab);
    
            Container
                .Bind<PlayerCamera>()
                .FromInstance(playerCameraInstance)
                .AsSingle();
        }
    }
}