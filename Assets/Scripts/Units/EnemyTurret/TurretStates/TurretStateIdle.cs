using Units.EnemyTurret.StructInfos;
using UnityEngine;

namespace Units.EnemyTurret.TurretStates
{
    public class TurretStateIdle : ITurretState
    {
        private readonly StateIdleInfo _stateAggresiveInfo;

        public TurretStateIdle(StateIdleInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;
        }

        public void Enter()
        {
            SetIdleColor();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            SetIdlePosition();
        }

        private void SetIdlePosition()
        {
            Transform gunTransfrom = _stateAggresiveInfo.TurretGunTarnsform;
            var localForward = Vector3.ProjectOnPlane(gunTransfrom.forward, Vector3.up);

            _stateAggresiveInfo.TurretRotator.RotateTo(gunTransfrom, localForward);
        }

        private void SetIdleColor()
        {
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.green;
        }
    }
}