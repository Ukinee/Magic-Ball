using System.Collections;
using MyInput;
using UnityEngine;
using UnityEngine.Events;

namespace Units.Ball.Abilities
{
    public class DashHandler : MonoBehaviour
    {
        [SerializeField] private Transform _direction;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private float _distanceUnits = 10f;
        [SerializeField] private float _cooldownSeconds = 1f;
        [SerializeField] private float _additionalSpeed = 10f;
        [SerializeField] private float _teleportDuration = 1f;
        [SerializeField] private bool _dashOnY;

        [SerializeField] private UnityEvent<Vector3, float> _dashing;

        private Rigidbody _rigidbody;
        private bool _isOnColldown;
        private bool _isTeleporting;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (_inputSystem.V == false || _isOnColldown || _isTeleporting)
                return;
        
            Vector3 direction = GetDirection(_direction);

            ChangeMovementVector(direction);
            StartCoroutine(TeleportCoroutine(direction));

            StartCoroutine(StartCooldown());
        }

        private Vector3 GetDirection(Transform direction)
        {
            Quaternion rotate = direction.rotation;

            if (_dashOnY == false)
                rotate.eulerAngles = new Vector3(0, rotate.eulerAngles.y, 0);

            return (rotate * Vector3.forward).normalized;
        }

        private void ChangeMovementVector(Vector3 newDirection)
        {
            _rigidbody.velocity = newDirection * (_rigidbody.velocity.magnitude + _additionalSpeed);
        }
        
        private Vector3 GetDashDistance(Vector3 direction)
        {
            
            
            var ray = new Ray(transform.position, direction);

            if (Physics.SphereCast(ray, transform.lossyScale.y / 2.1f, out RaycastHit hit, _distanceUnits))
                return direction * (hit.distance + transform.lossyScale.y / 2);
        
            return direction * _distanceUnits;
        }

        //Если сферический рейкаст попал куда-то, то расстояние будет меньше, но все равно займет _duration.
    
        private IEnumerator TeleportCoroutine(Vector3 direction)
        {
            Vector3 deltaPosition = GetDashDistance(direction);
            
            _isTeleporting = true;
            Vector3 velocity = _rigidbody.velocity;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = startPosition + deltaPosition;
            float spentTime = 0;
            
            var resultTeleportDuration = _teleportDuration * (deltaPosition.magnitude / _distanceUnits);
            
            _dashing?.Invoke(direction, resultTeleportDuration);
            
            _rigidbody.isKinematic = true;
        
            while (spentTime < 0.90f)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, spentTime);
                spentTime += Time.deltaTime * (1 / resultTeleportDuration);

                yield return new WaitForEndOfFrame();
            }

            _rigidbody.isKinematic = false;
            _rigidbody.velocity = velocity;
            _isTeleporting = false;
        }

        private IEnumerator StartCooldown()
        {
            _isOnColldown = true;

            yield return new WaitForSeconds(_cooldownSeconds);

            _isOnColldown = false;
        }
    }
}