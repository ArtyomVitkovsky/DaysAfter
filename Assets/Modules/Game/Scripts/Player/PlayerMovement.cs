using System;
using Modules.Main.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Modules.Game.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MoveDirection moveDirection;
        [SerializeField] private Rotate rotate;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float height;
        [SerializeField] private float gravity;
        [SerializeField] private float mass;
        [SerializeField] private float drag;

        private InputService inputService;
        private MouseInput mouseInputService;
        private Player player;

        private Vector3 targetDirection;

        [Inject]
        private void Construct(InputService keyboardInput, MouseInput mouseInput, Player player)
        {
            SetupInput(keyboardInput, mouseInput, player);
        }

        private void SetupInput(InputService keyboardInput, MouseInput mouseInput, Player player)
        {
            this.player = player;
            moveDirection = new MoveDirection(transform, player.MovementStats);
            rotate = new Rotate(transform);

            inputService = keyboardInput;
            inputService.OnXAxisMove += moveDirection.SetX;
            inputService.OnYAxisMove += moveDirection.SetY;
            inputService.OnZAxisMove += moveDirection.SetZ;
            
            mouseInputService = mouseInput;
            mouseInputService.OnXAxisMove += rotate.XRotate;
        }

        private bool IsGrounded()
        {
            Physics.Raycast(transform.position, Vector3.down, out var hitInfo, height);

            return hitInfo.transform != null;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void FixedUpdate()
        {
            var direction = moveDirection.HorizontalDirection * (Time.fixedDeltaTime * player.MovementStats.Speed)
                            + moveDirection.VerticalDirection * (Time.fixedDeltaTime * player.MovementStats.JumpForce);

            if (!IsGrounded())
            {
                direction += Vector3.down * (9.81f * mass * Time.fixedDeltaTime);
            }
            else
            {
                direction += Vector3.down * (gravity * Time.fixedDeltaTime);
            }

            targetDirection = Vector3.Lerp(targetDirection, direction, Time.fixedDeltaTime * drag);
            
            characterController.Move(targetDirection);
        }

        private void OnDestroy()
        {
            inputService.OnXAxisMove -= moveDirection.SetX;
            inputService.OnYAxisMove -= moveDirection.SetY;
            inputService.OnZAxisMove -= moveDirection.SetZ;
            
            mouseInputService.OnXAxisMove -= rotate.XRotate;
        }
    }
}