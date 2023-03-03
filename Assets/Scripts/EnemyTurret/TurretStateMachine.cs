using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyTurret
{
    [RequireComponent(typeof(TurretInfo))]
    public class TurretStateMachine : MonoBehaviour
    {
        private TurretInfo _turretInfo;
        
        private Dictionary<Type, ITurretState> _turretStatesMap;
        private ITurretState _currentState;

        private void Start()
        {
            _turretInfo = GetComponent<TurretInfo>();
            
            InitializeStates();
            SetState<TurretStateIdle>();
        }

        private void InitializeStates()
        {
            _turretStatesMap = new Dictionary<Type, ITurretState>
            {
                [typeof(TurretStateIdle)] = new TurretStateIdle(_turretInfo.StateAggresiveInfo),
                [typeof(TurretStateSearching)] = new TurretStateSearching(),
                [typeof(TurretStateAggressive)] = new TurretStateAggressive(_turretInfo.StateAggresiveInfo)
            };
        }

        public void SetState<T>()
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

        private void Update()
        {
            _currentState.Update();
        }
    }
}
