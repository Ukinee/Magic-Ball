using Units.EnemyTurret.StructInfos;
using UnityEngine;

namespace Units.EnemyTurret.TurretStates
{
    public class TurretStateDead : ITurretState
    {
        private readonly StateDeadInfo _stateDeadInfo;
        private Vector3 _targetRotation;
        private Transform _gunTransform;

        public TurretStateDead(StateDeadInfo stateDeadInfo)
        {
            _stateDeadInfo = stateDeadInfo;
        }

        public void Enter()
        {
            //play particles (смотри как у абрамсов горит боекомплект)
            _stateDeadInfo.DeathParticleSystem.Play();
            _stateDeadInfo.TargetSelector.enabled = false;
            _gunTransform = _stateDeadInfo.TurretGunTransform;
            _targetRotation = _gunTransform.TransformDirection(new Vector3(0, -0.5f, 1));
        }

        public void Exit()
        {
            throw new System.Exception("Турель не может выйти из состояния смерти, как ты вообще это сделал?");
        }

        public void Update()
        {
            Quaternion cachedRotation = _gunTransform.rotation;
            _stateDeadInfo.TurretRotator.RotateTo(_gunTransform, _targetRotation);

            if (cachedRotation != _gunTransform.rotation) 
                return;
            
            _stateDeadInfo.StateMachine.enabled = false;
        }
    }
}