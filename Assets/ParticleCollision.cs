using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionVfx;

    private ParticleSystem _bulletsParticleSystem;

    private void Start()
    {
        _bulletsParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        List<ParticleCollisionEvent> collisionEvents = new();
        _bulletsParticleSystem.GetCollisionEvents(other, collisionEvents);

        ParticleCollisionEvent currentEvent = collisionEvents[0];
        
        Instantiate(_collisionVfx, currentEvent.intersection, Quaternion.LookRotation(currentEvent.velocity));
        collisionEvents.Clear();
    }
}