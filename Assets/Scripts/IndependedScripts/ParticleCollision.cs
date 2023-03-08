using System.Collections.Generic;
using ForceMovable;
using Units.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace IndependedScripts
{
    public class ParticleCollision : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collisionBulletHoleVfx;
        [SerializeField] private int _damage;

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
            if (other.TryGetComponent(out ICanBeHit movable))
            {
                movable.HandleHit(direction, _damage);
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