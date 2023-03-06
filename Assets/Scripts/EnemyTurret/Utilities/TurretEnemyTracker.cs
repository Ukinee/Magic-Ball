using UnityEngine;

namespace EnemyTurret.Utilities
{
    public class TurretEnemyTracker
    {
        private readonly TurretRotationCalclulator _rotationCalclulator;
        private readonly TargetSelector _targetSelector;
        private readonly float _rotationSpeed;

        public TurretEnemyTracker(TargetSelector targetSelector, TurretRotationCalclulator rotationCalclulator, float rotationSpeed)
        {
            _rotationCalclulator = rotationCalclulator;
            _rotationSpeed = rotationSpeed;
            _targetSelector = targetSelector;
        }

        public void Rotate(Transform partTransform, Vector3 constraint)
        {
            var targetPosition = _targetSelector.Target.position; 
            
            partTransform.rotation = 
                _rotationCalclulator.Calclulate(targetPosition, partTransform, constraint, _rotationSpeed);
        }
    }
}