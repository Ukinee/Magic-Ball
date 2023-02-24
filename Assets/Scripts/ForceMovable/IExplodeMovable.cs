using UnityEngine;

namespace ForceMovable
{
    public interface IExplodeMovable
    {
        public void Explode(Vector3 direction, float force, float explosionRadius);
    }
}