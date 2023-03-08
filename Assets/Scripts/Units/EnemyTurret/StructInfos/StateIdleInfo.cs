using Units.EnemyTurret.Utilities;
using UnityEngine;

namespace Units.EnemyTurret.StructInfos
{
    public struct StateIdleInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly Transform TurretGunTarnsform;
        public readonly TurretRotator TurretRotator;

        public StateIdleInfo(
            MeshRenderer turretGunMeshRenderer, 
            Transform turretGunTarnsform,
            TurretRotator turretRotator)
        {
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretGunTarnsform = turretGunTarnsform;
            TurretRotator = turretRotator;
        }
    }
}