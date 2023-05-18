using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Game.Scripts
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected UnitMovementStats unitMovementStats;
        
        public UnitMovementStats MovementStats => unitMovementStats;
        
    }
}