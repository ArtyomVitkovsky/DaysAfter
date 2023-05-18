using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int poolSize;
        private ObjectsPool<Enemy> enemyPool;

        private IEnemyFactory _enemyFactory;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            enemyPool = new ObjectsPool<Enemy>(transform, poolSize, true);

            for (int i = 0; i < poolSize; i++)
            {
                var enemy = _enemyFactory.Create(transform.position, transform);
                enemyPool.AddObjectToPool(new PoolObject<Enemy>(enemy));
            }
        }
    }
}