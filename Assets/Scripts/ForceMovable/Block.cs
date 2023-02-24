using System;
using UnityEngine;

namespace ForceMovable
{
    public class Block : MonoBehaviour, IExplodeMovable, IBulletMovable
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Explode(Vector3 direction, float force, float explosionRadius)
        {
            _rigidbody.AddExplosionForce(force, direction, explosionRadius);
        }

        public void BulletMove(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
