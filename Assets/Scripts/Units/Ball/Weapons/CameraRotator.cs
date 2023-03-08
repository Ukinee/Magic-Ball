using MyInput;
using UnityEngine;

namespace Units.Ball.Weapons
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private float _sensivity = 0.5f;
        [SerializeField] private InputSystem _inputSystem;

        private Vector2 _turn;

        public void OnTeleport(Quaternion newRotation)
        {
            //_turn.x += newRotation.eulerAngles.x;
            _turn.y += newRotation.eulerAngles.y;
        }

        private void Update()
        {
            _turn.y += _inputSystem.MouseY * _sensivity;
            _turn.x += _inputSystem.MouseX * _sensivity;

            _turn.y = Mathf.Clamp(_turn.y, -60, 60);

            transform.localRotation = Quaternion.Euler(-_turn.y, _turn.x, 0);
        }
    }
}
