using Modules.Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private PlayerCamera playerCamera;
        public override void InstallBindings()
        {
            BindPlayer();
            
            BindPlayerCamera();
        }

        

        private void BindPlayerCamera()
        {
            Container
                .Bind<PlayerCamera>()
                .FromInstance(playerCamera)
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container
                .Bind<Player.Player>()
                .FromInstance(player)
                .AsSingle();
        }

        
    }
}