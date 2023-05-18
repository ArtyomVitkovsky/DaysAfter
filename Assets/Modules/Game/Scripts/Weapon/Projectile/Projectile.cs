using System;
using System.Collections;
using UnityEngine;

namespace Modules.Game.Scripts.Weapon.Projectile
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected float ballisticForce;
        [SerializeField] protected float damage;
        protected UnitBattleStats damagedUnit;

        private Coroutine disableCoroutine;
        
        public void Damage()
        {
            damagedUnit.ReceiveDamage(damage);
        }

        public void AddBallisticForce()
        {
            gameObject.SetActive(true);
            _rigidbody.AddForce(transform.forward * ballisticForce, ForceMode.Impulse);
            
            disableCoroutine = StartCoroutine(DisableCoroutine(10f));
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out UnitBattleStats unitStats))
            {
                damagedUnit = unitStats;
                Damage();
            }
        }

        protected IEnumerator DisableCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if(disableCoroutine != null) StopCoroutine(disableCoroutine);
            transform.localPosition = Vector3.zero;
            
            _rigidbody.isKinematic = false;
        }
    }
}