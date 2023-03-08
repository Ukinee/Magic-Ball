using Units.EnemyTurret.StructInfos;
using Units.EnemyTurret.Utilities;
using UnityEngine;

namespace Units.EnemyTurret
{
    public class TurretInfo : MonoBehaviour
    {
        [SerializeField] private TargetSelector _targetSelector;
        [SerializeField] private MeshRenderer _gunMeshRenderer;
        [SerializeField] private ParticleSystem _shootingParticleSystem;
        [SerializeField] private Transform _turretGunTarnsform;
        [SerializeField] private Transform _turretHeadTransform;
        [SerializeField] private TurretStateMachine _turretStateMachine;
        [SerializeField] private ParticleSystem _deathParticleSystem;
        [SerializeField] private float _rotationSpeed;

        private TurretRotator _turretRotator;
        
        public StateAggresiveInfo StateAggresiveInfo;
        public StateIdleInfo StateIdleInfo;
        public StateSearchingInfo StateSearchingInfo;
        public StateDeadInfo StateDeadInfo;

        public void Initialize()
        {
            InitTurretRotator(); // можно 1 экземпляр всем турелям 
            
            InitStateAggresiveInfo();
            InitStateSearchingInfo();
            InitStateIdleInfo();
            InitStateDeadInfo();
        }
        
        private void InitStateDeadInfo()
        {
            StateDeadInfo = new StateDeadInfo(
                _gunMeshRenderer,
                _targetSelector,
                _turretStateMachine,
                _turretGunTarnsform,
                _turretRotator,
                _deathParticleSystem
            );
        }
        
        private void InitTurretRotator()
        {
            var rotationCalclulator = new TurretRotationCalculator();
            
            _turretRotator = new TurretRotator(
                rotationCalclulator,
                _turretGunTarnsform,
                _turretHeadTransform,
                _rotationSpeed
                );
        }

        private void InitStateAggresiveInfo()
        {
            StateAggresiveInfo = new StateAggresiveInfo(
                _shootingParticleSystem,
                _gunMeshRenderer,
                _turretRotator,
                _targetSelector
            );
        }

        private void InitStateSearchingInfo()
        {
            StateSearchingInfo = new StateSearchingInfo(
                _gunMeshRenderer,
                _turretRotator,
                _targetSelector
            );
        }

        private void InitStateIdleInfo()
        {
            StateIdleInfo = new StateIdleInfo(
                _gunMeshRenderer,
                _turretGunTarnsform,
                _turretRotator
            );
        }
    }
}