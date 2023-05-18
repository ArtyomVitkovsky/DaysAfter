using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Weapon.Projectile.Factory
{
    public class ExplosiveProjectileFactory : MonoBehaviour, IProjectileFactory
    {
        [SerializeField] private ExplosiveProjectile explosiveProjectile;
        [Inject] private IInstantiator instantiator;

        public IProjectile Create()
        {
            var projectile = instantiator.InstantiatePrefabForComponent<ExplosiveProjectile>(explosiveProjectile);
            return projectile;
        }

        public IProjectile Create(Vector3 startPosition)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    explosiveProjectile, 
                    startPosition, 
                    Quaternion.identity, 
                    null);

            return projectile;
        }

        public IProjectile Create(Vector3 startPosition, Transform parent)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    explosiveProjectile, 
                    startPosition,
                    Quaternion.identity, 
                    parent);
            
            return projectile;
        }

        public IProjectile Create(Vector3 startPosition, Vector3 rotation, Transform parent)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    explosiveProjectile, 
                    startPosition, 
                    Quaternion.Euler(rotation),
                    parent);
            
            return projectile;
        }
    }
}