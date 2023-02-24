using Input;
using UnityEngine;

namespace LEGACY
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private float _chargeTime;
        [SerializeField] private float _randomDeviation;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _shootFrom;
    
        private float _currentChargeTime;
    
        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (_inputSystem.RMB != 0)
                _currentChargeTime -= Time.deltaTime;
            else
                SetCooldown();

            if (_currentChargeTime > 0)
                return;

            SetCooldown();
            ShootMachineGun();
        }

        private void ShootMachineGun()
        {
            Vector3 rotation = _shootFrom.rotation.eulerAngles;
            
            Quaternion resultRotation = Quaternion.Euler(
                rotation.x + _randomDeviation,
                rotation.y + _randomDeviation,
                rotation.z + _randomDeviation
            );
            
            Instantiate(_bulletPrefab, _shootFrom.position, resultRotation);
        }
    
        private void SetCooldown()
        {
            _currentChargeTime = _chargeTime;
        }
    }
}
