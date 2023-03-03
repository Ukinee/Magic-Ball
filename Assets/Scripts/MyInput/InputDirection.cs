using UnityEngine;

namespace MyInput
{
    public class InputDirection : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;

        private void Update()
        {
            float xInput = 0;
            float yInput = 0;
        
            var horizontal = _inputSystem.Horizontal;
            var vertical = _inputSystem.Vertical;
        
            if (horizontal != 0 && vertical == 0)
                xInput = horizontal < 0 ? -90 : 90;

            if (vertical != 0 && horizontal == 0)
                xInput = vertical < 0 ? 180 : 0;

            if (vertical > 0 && horizontal != 0)
                yInput = horizontal < 0 ? -45 : 45;

            if (vertical < 0 && horizontal != 0)
                yInput = horizontal < 0 ? -135 : 135;

            transform.localRotation = Quaternion.Euler(0, xInput + yInput, 0);
        }
    }
}