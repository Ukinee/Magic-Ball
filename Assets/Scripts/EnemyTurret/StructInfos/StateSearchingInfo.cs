using EnemyTurret.Utilities;
using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateSearchingInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly Transform TurretHeadTarnsform;
        public readonly TurretEnemyTracker TurretEnemyTracker;

        public StateSearchingInfo(Transform turretHeadTarnsform, MeshRenderer turretGunMeshRenderer, TurretEnemyTracker turretEnemyTracker)
        {
            TurretHeadTarnsform = turretHeadTarnsform;
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretEnemyTracker = turretEnemyTracker;
        }
    }
}