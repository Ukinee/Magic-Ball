using System.Collections.Generic;
using ForceMovable;
using MyInput;
using Units.Interfaces;
using UnityEngine;

namespace Units.Ball.Weapons
{
    public class Railgun : MonoBehaviour
    {
        [SerializeField] private float _chargeTime;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _shootFrom;
        [SerializeField] private float _maxShootDistance = 200f;
        [SerializeField] private int _damage;
        [SerializeField] private float _explosionRadius = 3f;
        [SerializeField] private float _explosionForce = 20f;
        [SerializeField] private ParticleSystem _explosionVfx;
        [SerializeField] private ParticleSystem _bulletHoleVfx;

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
            if (_inputSystem.Lmb)
            {
                _currentChargeTime -= Time.deltaTime;
            }
            else
            {
                SetCooldown();
            }

            if (_currentChargeTime > 0)
                return;

            SetCooldown();
            Shoot();
        }

        private void Shoot()
        {
            if (Physics.Raycast(_shootFrom.position, _shootFrom.forward, out RaycastHit hit, _maxShootDistance))
            {
                if(hit.collider.TryGetComponent(out ICanBeHit damageable))
                    damageable.HandleHit(hit.normal, _damage);
                
                var foundColliders = Physics.OverlapSphere(hit.point, _explosionRadius);
                float clipFixingValue = _explosionVfx.shape.radius / 2;
                hit.point = (hit.normal * clipFixingValue) + hit.point;
            
                Instantiate(_explosionVfx, hit.point, _shootFrom.rotation);
                Instantiate(_bulletHoleVfx, hit.point,
                    Quaternion.LookRotation(-1 * hit.normal),
                    hit.transform
                );

                ExplodeAll(foundColliders, hit);
            }
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