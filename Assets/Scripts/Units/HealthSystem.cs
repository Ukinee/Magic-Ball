using Units.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    public class HealthSystem : MonoBehaviour, ICanBeHit
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent<Vector3> _hitEvent;
        [SerializeField] private UnityEvent _deathEvent;

        private bool IsAlive => _health > 0;

        public void HandleHit(Vector3 direction, int amount)
        {
            if(amount >= 0 && IsAlive)
                TakeDamage(amount);
        
            _hitEvent?.Invoke(direction);
        }

        private void TakeDamage(int amount)
        {
            _health -= amount;

            if(IsAlive == false)
                _deathEvent?.Invoke();
        }
    }
}