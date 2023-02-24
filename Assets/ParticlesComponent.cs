using System.Collections;
using UnityEngine;

public class ParticlesComponent : MonoBehaviour
{
    private void OnEnable()
    {
        var particles = GetComponent<ParticleSystem>();
        particles.Play();

        var particlesLifeTime = particles.main.duration + particles.main.startLifetime.constantMax;

        StartCoroutine(Destroy(particlesLifeTime));
    }

    private IEnumerator Destroy(float lifeDuration)
    {
        yield return new WaitForSeconds(lifeDuration);

        Destroy(gameObject);
    }
}