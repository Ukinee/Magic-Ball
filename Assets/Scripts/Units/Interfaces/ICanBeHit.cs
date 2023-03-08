using UnityEngine;

namespace Units.Interfaces
{
    public interface ICanBeHit
    {
        public void HandleHit(Vector3 direction, int amount);
    }
}