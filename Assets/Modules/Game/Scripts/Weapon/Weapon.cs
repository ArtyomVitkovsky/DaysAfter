using System;
using Modules.Game.Scripts.Weapon.Interfaces;
using UnityEngine;

namespace Modules.Game.Scripts.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponMag mag;
        [SerializeField] private float fireDelay;

        private float lastFireDelay; 
        
        public void PerformAttack()
        {
            if (mag.IsLoaded && lastFireDelay >= fireDelay)
            {
                mag.RetrieveProjectile().AddBallisticForce();
                lastFireDelay = 0;
            }
        }

        private void Update()
        {
            lastFireDelay += Time.deltaTime;
        }
    }
}