using UnityEngine;

namespace Pickups
{
    public class PickupBehaviour : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _height;
        [SerializeField] private float _heightChangeSpeed = 1;

        private Transform _transform;
        private float _startYPosition;
        private float _time;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _startYPosition = _transform.position.y;
        }

        private void Update()
        {
            Rotate();
            Move();
        }

        private void Move()
        {
            _time += Time.deltaTime * _heightChangeSpeed;
            _time %= (Mathf.PI * 2);
            var yDelta = (Mathf.Sin(_time) + 1) / 2; //[-1, 1] => [0, 1]
            yDelta *= _height;
        
            Vector3 position = _transform.position;
            var newPosition = new Vector3(position.x, _startYPosition + yDelta, position.z);
            _transform.position = newPosition;
        }

        private void Rotate()
        {
            var rotateAngle = _rotateSpeed * Time.deltaTime;
            _transform.Rotate(rotateAngle, rotateAngle, rotateAngle);
        }
    }
}