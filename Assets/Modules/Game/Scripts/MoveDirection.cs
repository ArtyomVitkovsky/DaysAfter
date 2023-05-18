using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Game.Scripts
{
    [Serializable]
    public class MoveDirection 
    {
        [SerializeField] private UnitMovementStats unitMovementStats;
        [SerializeField] private Vector3 _horizontalMoveDirection;
        [SerializeField] private Vector3 _verticalMoveDirection;
        private Transform _transform;
        private float x;
        private float z;
        private float y;
        
        public MoveDirection(Transform transform, UnitMovementStats unitMovementStats)
        {
            this.unitMovementStats = unitMovementStats;
            _transform = transform;
        }

        public Vector3 HorizontalDirection
        {
            get
            {
                var horizontalMove = (_transform.right * x + _transform.forward * z) * unitMovementStats.Speed;
                _horizontalMoveDirection = horizontalMove;
                return _horizontalMoveDirection;
            }
        }
        
        public Vector3 VerticalDirection
        {
            get
            {
                var verticalMove = Vector3.up * y;
                _verticalMoveDirection = verticalMove;
                return _verticalMoveDirection;
            }
        }

        public void SetX(float x)  
        {
            this.x = x;
        }
        
        public void SetY(float y)
        {
            // if (y == 0) y = -9.81f;
            // else y *= unitMovementStats.JumpForce;
            this.y = y;
        }
        
        public void SetZ(float z)
        {
            this.z = z;
        }
        
    }
}