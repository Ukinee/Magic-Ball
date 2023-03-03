using EnemyTurret.StructInfos;
using UnityEngine;

namespace EnemyTurret
{
    public class TurretStateIdle : ITurretState
    {
        private readonly StateAggresiveInfo _stateAggresiveInfo;
        private readonly MeshRenderer _meshRenderer;
        
        public TurretStateIdle(StateAggresiveInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Idle State");
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.green;
        }

        public void Exit()
        {
            Debug.Log("Exit Idle State");
        }

        public void Update()
        {
            //throw new System.NotImplementedException();
        }
    }
}
