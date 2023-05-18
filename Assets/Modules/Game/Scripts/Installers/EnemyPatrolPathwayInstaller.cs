using Modules.Game.Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Installers
{
    public class EnemyPatrolPathwayInstaller : MonoInstaller
    {
        [SerializeField] private EnemyPatrolPathway pathWayPrefab;
        public override void InstallBindings()
        {
            var pathWayInstance = Container
                .InstantiatePrefabForComponent<EnemyPatrolPathway>(pathWayPrefab);
    
            Container.Bind<EnemyPatrolPathway>().FromInstance(pathWayInstance).AsSingle();
        }
    }
}