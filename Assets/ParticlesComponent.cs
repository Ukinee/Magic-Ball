using System;
using System.Collections;
using UnityEngine;

public class ParticlesComponent : MonoBehaviour, ISelfDestructable
{
    protected void OnEnable()
    {
        var particles = GetComponent<ParticleSystem>();
        particles.Play();

        ParticleSystem.MainModule main = particles.main;
        var particlesLifeTime = main.duration + main.startLifetime.constantMax;

        StartCoroutine(Destruct(particlesLifeTime));
    }

    public IEnumerator Destruct(float lifeDuration)
    {
        yield return new WaitForSeconds(lifeDuration);

        Destroy(gameObject);
    }
}