using System;
using System.Collections.Generic;
using Units.EnemyTurret.TurretStates;
using UnityEngine;

namespace Units.EnemyTurret
{
    [RequireComponent(typeof(TurretInfo))]
    public class TurretStateMachine : MonoBehaviour
    {
        private TurretInfo _turretInfo;
        
        private Dictionary<Type, ITurretState> _turretStatesMap;
        private ITurretState _currentState;

        private void Awake()
        {
            _turretInfo = GetComponent<TurretInfo>();
            _turretInfo.Initialize();
            
            InitializeStates();
            SetState<TurretStateIdle>();
        }

        private void InitializeStates()
        {
            _turretStatesMap = new Dictionary<Type, ITurretState>
            {
                [typeof(TurretStateIdle)] = new TurretStateIdle(_turretInfo.StateIdleInfo),
                [typeof(TurretStateSearching)] = new TurretStateSearching(_turretInfo.StateSearchingInfo),
                [typeof(TurretStateAggressive)] = new TurretStateAggressive(_turretInfo.StateAggresiveInfo),
                [typeof(TurretStateDead)] = new TurretStateDead(_turretInfo.StateDeadInfo)
            };
        }

        private void SetState<T>()
        {
            _currentState?.Exit();
            _currentState = _turretStatesMap[typeof(T)];
            _currentState.Enter();
        }

        public void SetStateAggressive()
        {
            SetState<TurretStateAggressive>();
        }
        
        public void SetStateSearching()
        {
            SetState<TurretStateSearching>();
        }
        
        public void SetStateIdle()
        {
            SetState<TurretStateIdle>();
        }
        
        public void SetStateDead()
        {
            SetState<TurretStateDead>();
        }

        private void Update()
        {
            _currentState.Update();
        }
    }
}
