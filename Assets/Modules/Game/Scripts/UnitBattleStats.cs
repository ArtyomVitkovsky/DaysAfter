using UnityEngine;

namespace Modules.Game.Scripts
{
    public class UnitBattleStats : MonoBehaviour, IStats
    {
        [SerializeField] private StatParameter<float> health;
        [SerializeField] private StatParameter<float> damage;
        [SerializeField] private StatParameter<float> activeRadius;
        
        public StatParameter<float> healthModifier;
        public StatParameter<float> damageModifier;
        public StatParameter<float> activeRadiusModifier;

        public float Health => health.value * healthModifier.value;

        public float Damage => damage.value * damageModifier.value;

        public float ActiveRadius => activeRadius.value * activeRadiusModifier.value;

        public void ReceiveDamage(float damage)
        {
            health.value -= damage;
        }
    }
}