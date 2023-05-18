using Modules.Game.Scripts.Enemy.Factory;
using UnityEngine;
using Zenject;
using IFactory = Modules.Game.Scripts.IFactory;

namespace Modules.Game.Scripts.Installers
{
    public class GroundEnemyFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GroundEnemyFactory factory;
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>().FromInstance(factory).AsSingle();
        }
    }
}