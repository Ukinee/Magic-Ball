using EnemyTurret.StructInfos;
using UnityEngine;

namespace EnemyTurret.TurretStates
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
            _stateSearchingInfo.TurretGunMeshRenderer.material.color = Color.yellow;
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }
    }
}