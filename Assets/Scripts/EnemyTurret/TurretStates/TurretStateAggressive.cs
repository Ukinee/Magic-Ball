using EnemyTurret.StructInfos;
using EnemyTurret.Utilities;
using UnityEngine;

namespace EnemyTurret.TurretStates
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