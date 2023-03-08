using UnityEngine;

namespace IndependedScripts
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Portal _connectedPortal;

        private bool _isTeleported;
        private float _cachedSpeed;

        private void Start()
        {
            print("Сломано TeleportRotation");
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.layer = 8;
        }

        private void OnTriggerExit(Collider other)
        {
            other.gameObject.layer = 7;
        }

        private void OnTriggerStay(Collider other)
        {
            Handle(other);
        }

        private void Handle(Collider other)
        {
            if (other.TryGetComponent(out Rigidbody foundRigidbody) == false)
                return;

            _cachedSpeed = foundRigidbody.velocity.magnitude;
            var zPosition = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;

            if (zPosition < 0)
            {
                Teleport(foundRigidbody);
            }
        }

        private void Teleport(Rigidbody other)
        {
            TeleportLocation(other.transform);
            TeleportRotation(other.transform);
            TeleportVelocity(other);
        }

        private void TeleportVelocity(Rigidbody other)
        {
            other.velocity = _connectedPortal.transform.forward * _cachedSpeed;
        }

        private void TeleportRotation(Transform otherTransform)
        {
            var difference = _connectedPortal.transform.rotation *
                             Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));

        
            otherTransform.rotation *= difference;
        }

        private void TeleportLocation(Transform other)
        {
            Vector3 localPosition = transform.worldToLocalMatrix.MultiplyPoint3x4(other.position);
            localPosition = new Vector3(-localPosition.x, localPosition.y, -localPosition.z);
            other.position = _connectedPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPosition);
        }
    }
}