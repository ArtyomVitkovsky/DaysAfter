using UnityEngine;
using UnityEngine.Events;

namespace Modules.Game.Scripts
{
    public class UnitMovementStats : MonoBehaviour, IStats
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        public float speedModifier;
        public float jumpModifier;

        public float Speed => speed * speedModifier;

        public float JumpForce => jumpForce * jumpModifier;
    }
}