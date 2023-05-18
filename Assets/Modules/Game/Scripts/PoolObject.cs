using System;

namespace Modules.Game.Scripts
{
    [Serializable]
    public class PoolObject<T>
    {
        public T instance;
        public bool isActive;

        public PoolObject(T instance)
        {
            this.instance = instance;
        }
    }
}