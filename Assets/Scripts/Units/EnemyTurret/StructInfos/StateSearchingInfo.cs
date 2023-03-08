using Units.EnemyTurret.Utilities;
using UnityEngine;

namespace Units.EnemyTurret.StructInfos
{
    public struct StateSearchingInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly TurretRotator TurretRotator;
        public readonly TargetSelector TargetSelector;

        public StateSearchingInfo(MeshRenderer turretGunMeshRenderer, TurretRotator turretRotator, TargetSelector targetSelector)
        {
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretRotator = turretRotator;
            TargetSelector = targetSelector;
        }
    }
}