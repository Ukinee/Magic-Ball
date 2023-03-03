using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateAggresiveInfo
    {
        public TargetTracker TargetTracker;
        public MeshRenderer TurretGunMeshRenderer;
        public Transform TurretHeadTarnsform;
        public Transform TurretGunTarnsform;
        public ParticleSystem ShootingParticleSystem;

        public StateAggresiveInfo(
            ParticleSystem shootingParticleSystem, 
            Transform turretGunTarnsform,
            Transform turretHeadTarnsform, 
            MeshRenderer turretGunMeshRenderer, 
            TargetTracker targetTracker)
        {
            ShootingParticleSystem = shootingParticleSystem;
            TurretGunTarnsform = turretGunTarnsform;
            TurretHeadTarnsform = turretHeadTarnsform;
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TargetTracker = targetTracker;
        }
    }
}