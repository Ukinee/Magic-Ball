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
            
            //Debug.DrawRay(gunTransform.position, Vector3.right);

            RotatePart(headTransform, Vector3.up, 70);
            RotatePart(gunTransform, Vector3.right, 70);
        }

        private void RotatePart(Transform partTransform, Vector3 constraints, float rotationSpeed)
        {
            Vector3 direction = _stateAggresiveInfo.TargetTracker.Target.position - partTransform.position;
            Quaternion rotation = partTransform.localRotation;
            
            GetNewRotation(rotation, direction, rotationSpeed).ToAngleAxis(out float angle, out Vector3 _);

            Debug.DrawRay(partTransform.position, partTransform.forward);
            
            partTransform.Rotate(constraints * angle);
        }
        
        private Quaternion GetNewRotation(Quaternion rotation, Vector3 direction, float rotationSpeed)
        {
            var angleDelta = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            return Quaternion.RotateTowards(rotation, targetRotation, angleDelta);
        }

        private Quaternion ConstraintRotation(Quaternion rotation, Vector3 constraints)
        {
            Vector3 rotationEuler = rotation.eulerAngles;

            rotationEuler.x *= constraints.x;
            rotationEuler.y *= constraints.y;
            rotationEuler.z *= constraints.z;

            return Quaternion.Euler(rotationEuler);
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