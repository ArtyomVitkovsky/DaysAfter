using System;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Player
{
    public class PlayerCamera : CameraFollower
    {
        [SerializeField] private Rotate rotate;
        [SerializeField] private Transform debugLookPoint;

        private Vector3 lookPoint;
        
        private Player playerUnit;
        private MouseInput mouseInput;

        public Vector3 LookPoint => lookPoint;

        [Inject]
        private void Construct(Player player, MouseInput mouseInput)
        {
            SetPlayerUnit(player);
            SetMouseInput(mouseInput);
        }

        private void SetPlayerUnit(Player playerUnit)
        {
            this.playerUnit = playerUnit;
            SetFollowTarget(this.playerUnit.transform);
        }

        private void SetMouseInput(MouseInput mouseInput)
        {
            rotate = new Rotate(transform);

            this.mouseInput = mouseInput;
            this.mouseInput.OnXAxisMove += rotate.XRotate;
            this.mouseInput.OnYAxisMove += rotate.YRotate;
        }

        private void Update()
        {
            var startPoint = cameraTransform.position;
            startPoint.z = playerUnit.transform.position.z;
            
            Physics.Raycast( startPoint, cameraTransform.forward, out var hitInfo);
            if (hitInfo.transform == null)
            {
                return;
            }
            
            lookPoint = hitInfo.point;

            debugLookPoint.position = lookPoint;
        }
    }
}