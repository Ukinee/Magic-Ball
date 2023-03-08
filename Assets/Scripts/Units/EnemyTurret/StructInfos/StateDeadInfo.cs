using Units.EnemyTurret.Utilities;
using UnityEngine;

namespace Units.EnemyTurret.StructInfos
{
    public struct StateDeadInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly TargetSelector TargetSelector;
        public readonly TurretStateMachine StateMachine;
        public readonly Transform TurretGunTransform;
        public readonly TurretRotator TurretRotator;
        public readonly ParticleSystem DeathParticleSystem;

        public StateDeadInfo(
            MeshRenderer turretGunMeshRenderer, 
            TargetSelector targetSelector, 
            TurretStateMachine stateMachine,
            Transform turretGunTransform,
            TurretRotator turretRotator,
            ParticleSystem particleSystem)
        {
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TargetSelector = targetSelector;
            StateMachine = stateMachine;
            TurretGunTransform = turretGunTransform;
            TurretRotator = turretRotator;
            DeathParticleSystem = particleSystem;
        }
    }
}