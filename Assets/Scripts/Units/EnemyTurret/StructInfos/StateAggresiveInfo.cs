using Units.EnemyTurret.Utilities;
using UnityEngine;

namespace Units.EnemyTurret.StructInfos
{
    public struct StateAggresiveInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly TurretRotator TurretRotator;
        public readonly TargetSelector TargetSelector;
        public readonly ParticleSystem ShootingParticleSystem;

        public StateAggresiveInfo(
            ParticleSystem shootingParticleSystem,
            MeshRenderer turretGunMeshRenderer,
            TurretRotator turretRotator,
            TargetSelector targetSelector)
        {
            ShootingParticleSystem = shootingParticleSystem;
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretRotator = turretRotator;
            TargetSelector = targetSelector;
        }
    }
}