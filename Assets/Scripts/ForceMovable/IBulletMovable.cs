using UnityEngine;

namespace ForceMovable
{
    public interface IBulletMovable
    {
        public void BulletMove(Vector3 direction, float force);
    }
}
