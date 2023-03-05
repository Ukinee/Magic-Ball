using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace EnemyTurret
{
    public class TargetTracker : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private UnityEvent _onTargetChange;
        [SerializeField] private UnityEvent _onTargetLost;

        private Collider _target;
        private readonly List<Collider> _targets = new();
        private bool _hadTargets = false;

        public Transform Target => _target.transform;

        private void FixedUpdate()
        {
            UpdateTargets();
        
            TryChangeTarget();
        }

        private void TryChangeTarget()
        {
            if (_targets.Contains(_target))
                return;
        
            if (_targets.Count != 0)
            {
                _hadTargets = true;
                _target = _targets[0];
                _onTargetChange?.Invoke();
            }
            else
            {
                if (_hadTargets == false)
                    return;

                _target = null;
                _hadTargets = false;
                _onTargetLost?.Invoke();
            }
        }

        private void UpdateTargets()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radius);

            if (colliders.Contains(_target))
                return;

            _targets.Clear();

            foreach (Collider foundCollider in colliders)
            {
                if (foundCollider.TryGetComponent<ITarget>(out _))
                {
                    _targets.Add(foundCollider);
                }
            }
        }
    }
}