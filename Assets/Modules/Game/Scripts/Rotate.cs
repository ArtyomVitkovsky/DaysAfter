using System;
using UnityEngine;

namespace Modules.Game.Scripts
{
    [Serializable]
    public class Rotate
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _angle;
        [SerializeField] private Vector2 _clampX;
        [SerializeField] private Vector2 _clampY;

        private bool _isXClamped;
        private bool _isYClamped;
        
        
        public Rotate(Transform transform)
        {
            _transform = transform;
            _isXClamped = false;
            _isYClamped = false;
        }
        
        
        public Rotate(Transform transform, bool isXClamped, Vector2 clampX)
        {
            _transform = transform;
            _isXClamped = isXClamped;
            _isYClamped = false;
            _clampX = clampX;
        }
        
        
        public Rotate(Transform transform, bool isXClamped, bool isYClamped, Vector2 clampX, Vector2 clampY)
        {
            _transform = transform;
            _isXClamped = isXClamped;
            _isYClamped = isYClamped;
            _clampX = clampX;
            _clampY = clampY;
        }

        public void XRotate(float x)
        {
            _angle.y += x;

            if (_isXClamped) _angle.x = Mathf.Clamp(_angle.x, _clampX.x, _clampX.y);

            _transform.rotation = Quaternion.Euler(_angle);
        }
        
        public void YRotate(float y)
        {
            _angle.x += y;
            
            if (_isYClamped) _angle.y = Mathf.Clamp(_angle.y, _clampY.x, _clampY.y);

            _transform.rotation = Quaternion.Euler(_angle);
        }
    }
}