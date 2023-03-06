using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateAggresiveInfo
    {
        public readonly TargetTracker TargetTracker;
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly Transform TurretHeadTransform;
        public readonly Transform TurretGunTransform;
        public readonly ParticleSystem ShootingParticleSystem;
        public readonly float UpRotationSpeed;

        public StateAggresiveInfo(
            ParticleSystem shootingParticleSystem, 
            Transform turretGunTransform,
            Transform turretHeadTransform, 
            MeshRenderer turretGunMeshRenderer, 
            TargetTracker targetTracker,
            float upRotationSpeed)
        {
            ShootingParticleSystem = shootingParticleSystem;
            TurretGunTransform = turretGunTransform;
            TurretHeadTransform = turretHeadTransform;
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TargetTracker = targetTracker;
            UpRotationSpeed = upRotationSpeed;
        }
    }
}