using UnityEngine;

namespace Modules.Game.Scripts
{
    interface IEnemyFactory
    {
        public Enemy.Enemy Create();
        public Enemy.Enemy Create(Vector3 startPosition);
        public Enemy.Enemy Create(Vector3 startPosition, Transform parent);
        public Enemy.Enemy Create(Vector3 startPosition, Vector3 rotation ,Transform parent);
    }
}