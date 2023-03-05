using EnemyTurret.StructInfos;
using UnityEngine;

namespace EnemyTurret.TurretStates
{
    public class TurretStateIdle : ITurretState
    {
        private readonly StateIdleInfo _stateAggresiveInfo;
        private readonly MeshRenderer _meshRenderer;

        public TurretStateIdle(StateIdleInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;
        }

        public void Enter()
        {
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.green;
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}