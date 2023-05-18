using UnityEngine;
using UnityEngine.AI;

namespace Modules.Game.Scripts.Weapon.Projectile
{
    public class ExplosiveProjectile : Projectile, IExplosiveProjectile
    {
        [SerializeField] private float explosiveForce;
        [SerializeField] private float explosiveRadius;
        [SerializeField] private GameObject explosion;

        protected override void OnCollisionEnter(Collision collision)
        {
            ReleaseExplosiveForce();
            base.OnCollisionEnter(collision);
            
            explosion.SetActive(true);
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;

            StartCoroutine(DisableCoroutine(1f));
        }

        public void ReleaseExplosiveForce()
        {
            var explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosiveRadius);
            foreach (Collider hit in colliders)
            {
                if(hit.gameObject == gameObject) continue;
                
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    if (rb.TryGetComponent(out NavMeshAgent navMeshAgent))
                    {
                        navMeshAgent.enabled = false;
                    }

                    rb.isKinematic = false;
                    rb.freezeRotation = false;
                    rb.AddExplosionForce(explosiveForce, explosionPos, explosiveRadius, 3.0F);
                }
            }
        }
    }
}