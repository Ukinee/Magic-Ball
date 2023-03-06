using EnemyTurret.StructInfos;
using EnemyTurret.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyTurret
{
    public class TurretInfo : MonoBehaviour
    {
        [FormerlySerializedAs("_targetTracker")] [SerializeField] private TargetSelector _targetSelector;
        [SerializeField] private MeshRenderer _gunMeshRenderer;
        [SerializeField] private ParticleSystem _shootingParticleSystem;
        [SerializeField] private Transform _turretGunTarnsform;
        [SerializeField] private Transform _turretHeadTransform;
        [SerializeField] private float _upRotationSpeed;

        private TurretEnemyTracker _turretEnemyTracker;
        
        public StateAggresiveInfo StateAggresiveInfo;
        public StateIdleInfo StateIdleInfo;
        public StateSearchingInfo StateSearchingInfo;

        public void Initialize()
        {
            InitTurretRotator();
            
            InitStateAggresiveInfo();
            InitStateSearchingInfo();
            InitStateIdleInfo();
        }

        private void InitTurretRotator()
        {
            var rotationCalclulator = new TurretRotationCalclulator();
            
            _turretEnemyTracker = new TurretEnemyTracker(
                _targetSelector,
                rotationCalclulator,
                _upRotationSpeed
                );
        }

        private void InitStateAggresiveInfo()
        {
            StateAggresiveInfo = new StateAggresiveInfo(
                _shootingParticleSystem,
                _gunMeshRenderer,
                _turretEnemyTracker
            );
        }

        private void InitStateSearchingInfo()
        {
            StateSearchingInfo = new StateSearchingInfo(
                _turretHeadTransform,
                _gunMeshRenderer,
                _turretEnemyTracker
            );
        }

        private void InitStateIdleInfo()
        {
            StateIdleInfo = new StateIdleInfo(
                _gunMeshRenderer,
                _turretGunTarnsform
            );
        }
    }
}