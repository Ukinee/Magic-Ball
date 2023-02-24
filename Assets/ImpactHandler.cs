using ForceMovable;
using UnityEngine;

public class ImpactHandler : MonoBehaviour
{
    public static void Handle(RaycastHit hit, float force, ParticleSystem impactVfx, Quaternion rotation)
    {
        PlayVfx(hit.point, impactVfx, rotation);
        
        if (hit.collider.TryGetComponent(out IBulletMovable targetBulletMovable) == false)
            return;
        
        Vector3 direction = CalclulateDirection(hit.point, hit.transform.position);
        targetBulletMovable.BulletMove(direction, force);
    }

    private static void PlayVfx(Vector3 hitPoint, ParticleSystem impactVfx, Quaternion rotation)
    {
        Instantiate(impactVfx, hitPoint, rotation);
    }

    private static Vector3 CalclulateDirection(Vector3 hitPoint, Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - hitPoint;
        
        return direction.normalized;
    }
}
