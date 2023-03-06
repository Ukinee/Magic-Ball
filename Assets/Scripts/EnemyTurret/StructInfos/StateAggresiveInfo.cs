using EnemyTurret.Utilities;
using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateAggresiveInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly TurretEnemyTracker TurretEnemyTracker;
        public readonly ParticleSystem ShootingParticleSystem;

        public StateAggresiveInfo(
            ParticleSystem shootingParticleSystem,
            MeshRenderer turretGunMeshRenderer,
            TurretEnemyTracker turretEnemyTracker)
        {
            ShootingParticleSystem = shootingParticleSystem;
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretEnemyTracker = turretEnemyTracker;
        }
    }
}