using EnemyTurret.StructInfos;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyTurret
{
    public class TurretInfo : MonoBehaviour
    {
        [SerializeField] private TargetTracker _targetTracker;
        [SerializeField] private MeshRenderer _gunMeshRenderer;
        [SerializeField] private ParticleSystem _shootingParticleSystem;
        [SerializeField] private Transform _turretGunTarnsform;
        [SerializeField] private Transform _turretHeadTransform;
        [SerializeField] private float _upRotationSpeed;

        public StateAggresiveInfo StateAggresiveInfo;
        public StateIdleInfo StateIdleInfo;
        public StateSearchingInfo StateSearchingInfo;

        public void Initialize()
        {
            StateAggresiveInfo = new StateAggresiveInfo(
                _shootingParticleSystem, 
                _turretGunTarnsform, 
                _turretHeadTransform,
                _gunMeshRenderer, 
                _targetTracker,
                _upRotationSpeed
            );

            StateSearchingInfo = new StateSearchingInfo(
                _turretHeadTransform,
                _gunMeshRenderer
            );

            StateIdleInfo = new StateIdleInfo(
                _gunMeshRenderer, 
                _turretGunTarnsform
            );
        }
    }
}