using UnityEngine;

namespace EnemyTurret.Utilities
{
    public class TurretRotationCalclulator
    {
        public Quaternion Calclulate(Vector3 targetPosition, Transform partTransform, Vector3 constraint, float anglePerSecond)
        {
            var rotationDelta = anglePerSecond * Time.deltaTime;
            Vector3 targetDirection = targetPosition - partTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            targetRotation = ConstraintRotation(targetRotation, constraint);

            return Quaternion.RotateTowards(
                partTransform.rotation, 
                targetRotation, 
                rotationDelta);
        }

        private static Quaternion ConstraintRotation(Quaternion rotation, Vector3 constraint)
        {
            Vector3 eulerAngles = rotation.eulerAngles;

            eulerAngles.x *= constraint.x;
            eulerAngles.y *= constraint.y;
            eulerAngles.z *= constraint.z;

            rotation.eulerAngles = eulerAngles;

            return rotation;
        }
    }
}