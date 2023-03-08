using System.Collections.Generic;
using System.Linq;
using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Units.EnemyTurret
{
    public class TargetSelector : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _coneAngle = 10;
        [SerializeField] private UnityEvent _onTargetGet;
        [SerializeField] private UnityEvent _onTargetLost;
        [SerializeField] private UnityEvent _targetEnteredFireZone;
        [SerializeField] private UnityEvent _targetLeftFireZone;

        private readonly List<Collider> _coneTargets = new();
        private readonly List<Collider> _sphereTargets = new();
        private Collider _target;
        private bool _hadTargetInSearchinZone;
        private bool _hadTargetInFireZone;

        public Vector3 Target => _target.transform.position;

        private void FixedUpdate()
        {
            GetSphereTargets(); // в идеале наверно все связанное со сферой вынести в отдельный класс,
                                // но я хз как заставить его выполняться первым

            if (_sphereTargets.Contains(_target))
            {
                UpdateTargetsInFireZone();
                HandleTargetInFireZone();
            }
            else
            {
                _coneTargets.Clear();
                ChangeTarget();
            }
        }

        private void GetSphereTargets()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radius);

            if (colliders.Contains(_target))
                return;
            
            _sphereTargets.Clear();
            
            if(colliders.Length == 0)
                return;

            foreach (Collider foundCollider in colliders)
                if (foundCollider.TryGetComponent<ITarget>(out _))
                    _sphereTargets.Add(foundCollider);
        }

        private void UpdateTargetsInFireZone()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            //Debug.DrawRay(transform.position, Vector3.forward * 3, Color.red);
            //Debug.DrawRay(transform.position, forward * 3, Color.green);
            
            var coneCastedColliders = PhysicsExtention.ConeOverlap(
                _sphereTargets,
                transform.position,
                forward,
                _coneAngle
            );

            if (coneCastedColliders.Contains(_target) && _hadTargetInFireZone)
                return;

            _coneTargets.Clear();
            _coneTargets.AddRange(coneCastedColliders);
        }

        private void HandleTargetInFireZone()
        {
            if (_coneTargets.Contains(_target))
            {
                if (_hadTargetInFireZone)
                    return;

                _targetEnteredFireZone?.Invoke();
                _hadTargetInFireZone = true;
            }
            else
            {
                if (_hadTargetInFireZone == false)
                    return;

                _targetLeftFireZone?.Invoke();
                _hadTargetInFireZone = false;
            }
        }

        private void ChangeTarget()
        {
            if (_sphereTargets.Count != 0)
            {
                _hadTargetInSearchinZone = true;
                _target = _sphereTargets[0];
                _onTargetGet?.Invoke();
            }
            else
            {
                if (_hadTargetInSearchinZone == false)
                    return;

                _target = null;
                _hadTargetInSearchinZone = false;
                _onTargetLost?.Invoke();
            }
        }
    }
}