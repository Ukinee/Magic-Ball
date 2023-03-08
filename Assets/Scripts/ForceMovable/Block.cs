using Units.Interfaces;
using UnityEngine;

namespace ForceMovable
{
    public class Block : MonoBehaviour, IExplodeMovable, IBulletMovable, ICanBeHit
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Explode(Vector3 epicenter, float force, float explosionRadius)
        {
            _rigidbody.AddExplosionForce(force, epicenter, explosionRadius);
        }

        public void BulletMove(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force);
        }

        public void HandleHit(Vector3 direction, int amount)
        {
            BulletMove(direction, amount);
        }
    }
}