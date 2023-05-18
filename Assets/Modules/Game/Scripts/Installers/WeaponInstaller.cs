using Modules.Game.Scripts.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Weapon.Weapon weapon;
        public override void InstallBindings()
        {
            Container.Bind<IWeapon>().FromInstance(weapon).AsSingle();
        }
    }
}