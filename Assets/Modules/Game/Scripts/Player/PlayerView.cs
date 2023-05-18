using System;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Player
{
    [Serializable]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem jetpackFlarePS;

        
        private InputService inputService;

        [Inject]
        private void Construct(InputService keyboardInput, MouseInput mouseInput, Player player)
        {
            SetupInput(keyboardInput, mouseInput, player);
        }
        
        private void SetupInput(InputService keyboardInput, MouseInput mouseInput, Player player)
        {
            inputService = keyboardInput;
            inputService.OnYAxisMove += SetFlareIntensity;
            inputService.OnXAxisMove += SetFlareVelocityX;
        }

        private void SetFlareIntensity(float intensity)
        {
            if (intensity == 0) intensity = 0.2f;
            
            var psModule = jetpackFlarePS.main;
            psModule.startLifetime = intensity;
        }
        
        private void SetFlareVelocityX(float velocity)
        {
            var velocityOverLifetime = jetpackFlarePS.velocityOverLifetime;
            velocityOverLifetime.xMultiplier = -velocity;
        }

    }
}