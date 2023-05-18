using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player.Player playerPrefab;
        public override void InstallBindings()
        {
            Player.Player playerInstance;
            playerInstance = Container.InstantiatePrefabForComponent<Player.Player>(playerPrefab);

            Container
                .Bind()
                .FromInstance(playerInstance)
                .AsSingle();
        }
    }
}