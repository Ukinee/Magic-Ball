using UnityEngine;

namespace EnemyTurret.TurretStates
{
    public interface ITurretState
    {
        public void Enter();
        public void Exit();
        public void Update();
    }
}
