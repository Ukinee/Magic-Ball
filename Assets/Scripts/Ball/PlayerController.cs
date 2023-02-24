using Input;
using UnityEngine;

namespace Ball
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private float _forceMultiplier;
        [SerializeField] private Transform _cameraPosition;
    
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            Vector3 position = transform.position;
            var circleLength = Mathf.PI * transform.lossyScale.y;

            Vector3 view = position - _cameraPosition.position;
            Vector3 frontDirection = new Vector3(view.x, 0, view.z).normalized;
            Vector3 sideDirection = Quaternion.Euler(0, 90, 0) * frontDirection;

            _rigidbody.AddForce(_forceMultiplier * _inputSystem.Vertical * circleLength * frontDirection);
            _rigidbody.AddForce(_forceMultiplier * _inputSystem.Horizontal * circleLength * sideDirection);
        }
    }
}
