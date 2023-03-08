using Units.EnemyTurret.StructInfos;
using UnityEngine;

namespace Units.EnemyTurret.TurretStates
{
    public class TurretStateSearching : ITurretState
    {
        private readonly StateSearchingInfo _stateSearchingInfo;
        private readonly Transform _targetTransform;

        public TurretStateSearching(StateSearchingInfo stateSearchingInfo)
        {
            _stateSearchingInfo = stateSearchingInfo;
        }
        
        public void Enter()
        {
            SetSearchingColor();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            PerformRotation();
        }

        private void PerformRotation()
        {
            Vector3 targetPosition = _stateSearchingInfo.TargetSelector.Target;

            _stateSearchingInfo.TurretRotator.TrackTarget(targetPosition);
        }

        private void SetSearchingColor()
        {
            _stateSearchingInfo.TurretGunMeshRenderer.material.color = Color.yellow;
        }
    }
}