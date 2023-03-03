using MyInput;
using UnityEngine;

namespace Ball
{
    public class VisualController : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Rigidbody _collider;
        [SerializeField] private Transform _cameraPosition;
        [SerializeField] private float _maxRadiansPerSecond = 12;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = _maxRadiansPerSecond;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.zero;
            AddTorque();
        }

        private void AddTorque()
        {
            float minimalVelocity = 0.01f;
            float circleLength = transform.lossyScale.y * Mathf.PI;

            Vector3 view = transform.position - _cameraPosition.position;
            Vector3 frontDirection = new Vector3(view.z, 0, -view.x).normalized;
            Vector3 sideDirection = Quaternion.Euler(Vector3.up * 90) * frontDirection;

            if (_inputSystem.HasInput && _collider.velocity.magnitude > minimalVelocity)
            {
                _rigidbody.AddTorque(frontDirection * _inputSystem.Vertical, ForceMode.Impulse);
                _rigidbody.AddTorque(sideDirection * _inputSystem.Horizontal, ForceMode.Impulse);
            }
            else
            {
                _rigidbody.angularVelocity = circleLength * new Vector3(_collider.velocity.z, 0, -_collider.velocity.x);
            }
        }
    }
}