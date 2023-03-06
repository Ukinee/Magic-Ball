using EnemyTurret.StructInfos;
using EnemyTurret.Utilities;
using UnityEngine;

namespace EnemyTurret.TurretStates
{
    public class TurretStateAggressive : ITurretState
    {
        private readonly TurretRotator _turretRotator = new();
        private readonly StateAggresiveInfo _stateAggresiveInfo;
        private readonly Transform _gunTransform;
        private readonly Transform _headTransform;
        private readonly float _upRotationSpeed;
        private readonly TargetTracker _targetTracker;
        private  Transform _targetTransform;

        public TurretStateAggressive(StateAggresiveInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;

            _targetTracker = _stateAggresiveInfo.TargetTracker;
            _gunTransform = _stateAggresiveInfo.TurretGunTransform;
            _headTransform = _stateAggresiveInfo.TurretHeadTransform;
            _upRotationSpeed = _stateAggresiveInfo.UpRotationSpeed;
        }

        public void Enter()
        {
            _targetTransform = _targetTracker.Target;
            
            Debug.Log("There you are!");
            SetAggresiveColor();
            StartShooting();
        }

        public void Exit()
        {
            StopShooting();
        }

        public void Update()
        {
            PerformRotation();
        }

        private void PerformRotation()
        {
            Vector3 position = _targetTransform.position;

            _turretRotator.RotatePart(position, _gunTransform, new Vector3(1, 1, 0), _upRotationSpeed);
            _turretRotator.RotatePart(position, _headTransform, Vector3.up, _upRotationSpeed);
        }

        private void SetAggresiveColor()
        {
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.red;
        }

        private void StartShooting()
        {
            ParticleSystem.MainModule mainModule = _stateAggresiveInfo.ShootingParticleSystem.main;
            mainModule.loop = true;
            _stateAggresiveInfo.ShootingParticleSystem.Play();
        }

        private void StopShooting()
        {
            ParticleSystem.MainModule mainModule = _stateAggresiveInfo.ShootingParticleSystem.main;
            mainModule.loop = false;
        }
    }
}