using System.Collections.Generic;
using ForceMovable;
using Input;
using UnityEngine;

namespace Ball
{
    public class Railgun : MonoBehaviour
    {
        [SerializeField] private float _chargeTime;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _shootFrom;
        [SerializeField] private float _maxShootDistance = 200f;
        
        [SerializeField] private float _explosionRadius = 3f;
        [SerializeField] private float _explosionForce = 20f;
        [SerializeField] private ParticleSystem _explosionVfx;

        private float _currentChargeTime;

        private void Start()
        {
            _currentChargeTime = _chargeTime;
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (_inputSystem.LMB != 0)
                _currentChargeTime -= Time.deltaTime;
            else
                SetCooldown();

            if (_currentChargeTime > 0)
                return;

            SetCooldown();
            Shoot();
        }

        private void Shoot()
        {
            Physics.Raycast(_shootFrom.position, _shootFrom.forward, out RaycastHit hit, _maxShootDistance);
            var foundColliders = Physics.OverlapSphere(hit.point, _explosionRadius);

            Instantiate(_explosionVfx, hit.point, _shootFrom.rotation);

            ExplodeAll(foundColliders, hit);
        }

        private void ExplodeAll(IEnumerable<Collider> foundColliders, RaycastHit hit)
        {
            foreach (Collider foundCollider in foundColliders)
            {
                if (foundCollider.TryGetComponent(out IExplodeMovable explodable) == false)
                    continue;

                explodable.Explode(hit.point, _explosionForce, _explosionRadius);
            }
        }

        private void SetCooldown()
        {
            _currentChargeTime = _chargeTime;
        }
    }
}