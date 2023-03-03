using System.Collections.Generic;
using UnityEngine;

namespace IndependedScripts
{
    public class ShieldAlarm : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        private readonly List<ParticleSystem> _bulletEmmiters = new();

        private void Awake()
        {
            print("ShieldAlarm - костыль");
            var bulletEmmiter = FindObjectsOfType<ParticleCollision>();

            foreach (ParticleCollision particleCollision in bulletEmmiter)
            {
                var currentParticleCollision = particleCollision.GetComponent<ParticleSystem>();
                currentParticleCollision.trigger.AddCollider(_collider);
                _bulletEmmiters.Add(currentParticleCollision);
            }
        }

        private void OnDestroy()
        {
            foreach (ParticleSystem currentParticleSystem in _bulletEmmiters)
            {
                currentParticleSystem.trigger.RemoveCollider(_collider);
            }
        }
    }
}