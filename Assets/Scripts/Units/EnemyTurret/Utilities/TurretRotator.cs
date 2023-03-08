using UnityEngine;

namespace Units.EnemyTurret.Utilities
{
    public class TurretRotator
    {
        private readonly TurretRotationCalculator _rotationCalculator;
        private readonly Transform _gunTransform;
        private readonly Transform _headTransform;
        private readonly float _rotationSpeed;

        public TurretRotator(
            TurretRotationCalculator rotationCalculator,
            Transform gunTransform,
            Transform headTransform,
            float rotationSpeed)
        {
            _rotationCalculator = rotationCalculator;
            _gunTransform = gunTransform;
            _headTransform = headTransform;
            _rotationSpeed = rotationSpeed;
        }

        public void RotateTo(Transform partTransform, Vector3 target)
        {
            partTransform.rotation = _rotationCalculator.RotateTo(target, partTransform, _rotationSpeed);
        }

        public void TrackTarget(Vector3 target)
        {
            Rotate(_gunTransform, target, new Vector3(1, 1, 0));
            Rotate(_headTransform, target, Vector3.up);
        }

        private void Rotate(Transform partTransform, Vector3 target, Vector3 constraint)
        {
            partTransform.rotation =
                _rotationCalculator.Calclulate(target, partTransform, constraint, _rotationSpeed);
        }
    }
}