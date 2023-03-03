using EnemyTurret.StructInfos;
using UnityEngine;

namespace EnemyTurret
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
            Debug.Log("Enter Aggressive State");
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.red;
        }
        
        public void Exit()
        {
            Debug.Log("Exit Aggressive State");
        }

        public void Update()
        {
        }
    }
}
