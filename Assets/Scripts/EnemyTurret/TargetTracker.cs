using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Extensions;

namespace EnemyTurret
{
    public class TargetTracker : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private UnityEvent _onTargetChange;
        [SerializeField] private UnityEvent _onTargetLost;

        private readonly List<Collider> _targets = new();
        private bool _hadTargets;
        private Collider _target;

        public Transform Target => _target.transform;

        private void FixedUpdate()
        {
            UpdateTargets();
            TryChangeTarget();
        }
        
        private void UpdateTargets()
        {
            var colliders = ConeCast.ConeCastAll(transform.position, _radius, transform.forward, 30);
            
            if (colliders.Contains(_target))
                return;

            _targets.Clear();

            foreach (Collider foundCollider in colliders)
                if (foundCollider.TryGetComponent<ITarget>(out _))
                    _targets.Add(foundCollider);
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
    }
}