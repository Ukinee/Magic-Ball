using Units.EnemyTurret.StructInfos;
using UnityEngine;

namespace Units.EnemyTurret.TurretStates
{
    public class TurretStateAggressive : ITurretState
    {
        private readonly StateAggresiveInfo _stateAggresiveInfo;

        public TurretStateAggressive(StateAggresiveInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;
        }

        public void Enter()
        {
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
            Vector3 targetPosition = _stateAggresiveInfo.TargetSelector.Target;
            
            _stateAggresiveInfo.TurretRotator.TrackTarget(targetPosition);
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