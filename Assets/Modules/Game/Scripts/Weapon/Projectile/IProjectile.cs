using System;

namespace Modules.Game.Scripts.Weapon.Projectile
{
    public interface IProjectile
    {
        public void Damage();
        
        public void AddBallisticForce();
    }
}