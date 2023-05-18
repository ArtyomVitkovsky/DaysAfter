using Modules.Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Weapon
{
    public class WeaponView : MonoBehaviour
    {
        private PlayerCamera playerCamera;
        [Inject]
        private void Construct(PlayerCamera playerCamera)
        {
            this.playerCamera = playerCamera;
        }

        private void Update()
        {
            transform.LookAt(playerCamera.LookPoint);
        }
    }
}