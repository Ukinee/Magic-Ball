using UnityEngine;

namespace ForceMovable
{
    public interface IExplodeMovable
    {
        public void Explode(Vector3 epicenter, float force, float explosionRadius);
    }
}