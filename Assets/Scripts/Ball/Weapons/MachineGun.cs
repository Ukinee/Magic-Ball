using UnityEngine;
using Input;

public class MachineGun : MonoBehaviour
{
    [SerializeField] private float _chargeTime;
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
        Instantiate(_bulletPrefab, _shootFrom.position, _shootFrom.rotation);
    }
    
    private void SetCooldown()
    {
        _currentChargeTime = _chargeTime;
    }
}
