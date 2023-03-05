using EnemyTurret.StructInfos;
using Unity.Mathematics;
using UnityEngine;

namespace EnemyTurret.TurretStates
{
    public class TurretStateAggressive : ITurretState
    {
        private readonly StateAggresiveInfo _stateAggresiveInfo;

        public TurretStateAggressive(StateAggresiveInfo stateAggresiveInfo)
        {
            _stateAggresiveInfo = stateAggresiveInfo;
        }

        public void Enter()
        {
            SetAggresiveColor();
            StartShooting();
        }

        public void Exit()
        {
            StopShooting();
        }

        public void Update()
        {
            Transform gunTransform = _stateAggresiveInfo.TurretGunTransform;
            Transform headTransform = _stateAggresiveInfo.TurretHeadTransform;

            RotatePart(gunTransform, Vector3.right, 20);
            RotatePart(headTransform, Vector3.up, 50);
        }

        private void RotatePart(Transform gunTransform, Vector3 constraint, float anglePerSecond)
        {
            var rotationDelta = anglePerSecond * Time.deltaTime;

            Vector3 targetDirection = _stateAggresiveInfo.TargetTracker.Target.position - gunTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            targetRotation = ConstraintRotation(targetRotation, constraint);

            gunTransform.localRotation = Quaternion.RotateTowards(
                gunTransform.localRotation, 
                targetRotation, 
                rotationDelta);;
        }

        private static Quaternion ConstraintRotation(Quaternion rotation, Vector3 constraint)
        {
            Vector3 eulerAngles = rotation.eulerAngles;

            eulerAngles.x *= constraint.x;
            eulerAngles.y *= constraint.y;
            eulerAngles.z *= constraint.z;

            rotation.eulerAngles = eulerAngles;

            return rotation;
        }

        private void SetAggresiveColor()
        {
            _stateAggresiveInfo.TurretGunMeshRenderer.material.color = Color.red;
        }

        private void StartShooting()
        {
            ParticleSystem.MainModule mainModule = _stateAggresiveInfo.ShootingParticleSystem.main;
            mainModule.loop = true;
            _stateAggresiveInfo.ShootingParticleSystem.Play();
        }

        private void StopShooting()
        {
            ParticleSystem.MainModule mainModule = _stateAggresiveInfo.ShootingParticleSystem.main;
            mainModule.loop = false;
        }
    }
}