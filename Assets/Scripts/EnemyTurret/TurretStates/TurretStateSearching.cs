using EnemyTurret.StructInfos;

namespace EnemyTurret.TurretStates
{
    public class TurretStateSearching : ITurretState
    {
        private readonly StateSearchingInfo _stateSearchingInfo;

        public TurretStateSearching(StateSearchingInfo stateSearchingInfo)
        {
            _stateSearchingInfo = stateSearchingInfo;
        }
        
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            
        }
    }
}