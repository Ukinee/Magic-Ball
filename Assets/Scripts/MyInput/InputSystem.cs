using UnityEngine;

namespace MyInput
{
    public class InputSystem : MonoBehaviour
    {
        public bool Lmb => Input.GetMouseButton(0);
        public bool RmbDown => Input.GetMouseButtonDown(1);
        public bool RmbUp => Input.GetMouseButtonUp(1);
        public bool V => Input.GetKeyDown(KeyCode.V);
        public bool Q => Input.GetKeyDown(KeyCode.Q);
        public bool E => Input.GetKeyDown(KeyCode.E);
        public bool C => Input.GetKeyDown(KeyCode.C);
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public float MouseY => Input.GetAxis("Mouse Y");
        public float MouseX => Input.GetAxis("Mouse X");

        public bool HasInput => Horizontal != 0 || Vertical != 0;
        public bool HasPortalInput => Q || E;
        public Vector3 Vector => new Vector3(Horizontal, 0, Vertical).normalized;
        public Vector3 TorqueVector => new Vector3(Vertical, 0, -Horizontal).normalized;
    }
}
