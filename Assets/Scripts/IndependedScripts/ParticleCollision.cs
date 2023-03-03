using System.Collections.Generic;
using ForceMovable;
using UnityEngine;

namespace IndependedScripts
{
    public class ParticleCollision : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collisionBulletHoleVfx;
        [SerializeField] private float _impactForce;

        private ParticleSystem _bulletsParticleSystem;

        private void Start()
        {
            _bulletsParticleSystem = GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            ParticleCollisionEvent currentEvent = GetCurrentCollisionEvent(other);

            CreateBulletHoleVfx(currentEvent, other);
            HandleImpact(other, currentEvent.velocity);
        }

        private void OnParticleTrigger()
        {
            var particles = new List<ParticleSystem.Particle>();

            _bulletsParticleSystem.GetTriggerParticles(
                ParticleSystemTriggerEventType.Enter,
                particles, 
                out ParticleSystem.ColliderData colliderData);

            for (var i = 0; i < particles.Count; i++)
            {
                ParticleSystem.Particle currentParticle = particles[i];
                currentParticle.remainingLifetime = 0;
                particles[i] = currentParticle;

                SphereCollider sphere = colliderData.GetCollider(i, 0).GetComponent<SphereCollider>();

                Vector3 spherePosition = sphere.transform.position;
            
                Vector3 projectedPoint = 
                    (currentParticle.position 
                     - spherePosition).normalized
                    * sphere.radius * sphere.transform.lossyScale.y
                    + spherePosition;
            
                Instantiate(_collisionBulletHoleVfx, projectedPoint,
                    Quaternion.LookRotation(currentParticle.position - spherePosition));
            }

            _bulletsParticleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        }

        private void CreateBulletHoleVfx(ParticleCollisionEvent currentEvent, GameObject other)
        {
            Instantiate(
                _collisionBulletHoleVfx,
                currentEvent.intersection,
                Quaternion.LookRotation(-1 * currentEvent.normal),
                other.transform
            );
        }

        private void HandleImpact(GameObject other, Vector3 direction)
        {
            if (other.TryGetComponent(out IBulletMovable movable))
            {
                movable.BulletMove(direction.normalized, _impactForce);
            }
        }

        private ParticleCollisionEvent GetCurrentCollisionEvent(GameObject other)
        {
            List<ParticleCollisionEvent> collisionEvents = new();
            _bulletsParticleSystem.GetCollisionEvents(other, collisionEvents);

            return collisionEvents[0];
        }
    }
}