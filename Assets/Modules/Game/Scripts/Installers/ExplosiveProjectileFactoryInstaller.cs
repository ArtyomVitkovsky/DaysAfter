using Modules.Game.Scripts.Weapon.Projectile.Factory;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class ExplosiveProjectileFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ExplosiveProjectileFactory factory;
        public override void InstallBindings()
        {
            Container.Bind<IProjectileFactory>().FromInstance(factory).AsSingle();
        }
    }
}