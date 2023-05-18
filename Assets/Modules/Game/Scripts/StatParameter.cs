using System;

namespace Modules.Game.Scripts
{
    [Serializable]
    public class StatParameter<T>
    {
        public T value;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChanged?.Invoke(this.value);
            }
        }

        public Action<T> OnChanged;
    }
}