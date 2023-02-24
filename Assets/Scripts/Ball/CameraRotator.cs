using Input;
using UnityEngine;

namespace Ball
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private float _sensivity = 0.5f;
        [SerializeField] private InputSystem _inputSystem;

        private Vector2 _turn;

        void Update()
        {
            _turn.y = Mathf.Clamp(_turn.y + _inputSystem.MouseY * _sensivity, -60, 60);
            _turn.x += _inputSystem.MouseX * _sensivity;

            transform.localRotation = Quaternion.Euler(-_turn.y, _turn.x, 0);
        }
    }
}
