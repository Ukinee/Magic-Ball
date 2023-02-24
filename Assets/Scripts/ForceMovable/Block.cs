using UnityEngine;

namespace ForceMovable
{
    public class Block : MonoBehaviour, IExplodeMovable
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Explode(Vector3 direction, float force, float explosionRadius)
        {
            _rigidbody.AddExplosionForce(force, direction, explosionRadius);
        }
    }
}
