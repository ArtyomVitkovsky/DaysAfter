using System;
using Modules.Game.Scripts.Weapon;
using Modules.Game.Scripts.Weapon.Interfaces;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Player
{
    public class Player : Unit
    {
        [SerializeField] protected UnitBattleStats unitBattleStats;
        
        private MouseInput mouseInput;
        private IWeapon weapon;
        [Inject]
        private void Construct(MouseInput mouseInput, IWeapon weapon)
        {
            this.weapon = weapon;

            SetupMouseInput(mouseInput);
        }

        private void SetupMouseInput(MouseInput mouseInput)
        {
            this.mouseInput = mouseInput;

            this.mouseInput.OnLMBclick += weapon.PerformAttack;
        }
        
        
    }
}