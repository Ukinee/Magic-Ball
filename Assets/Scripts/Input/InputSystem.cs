using UnityEngine;

namespace Input
{
    public class InputSystem : MonoBehaviour
    {
        public float LMB => UnityEngine.Input.GetAxis("Fire1");
        public float RMB => UnityEngine.Input.GetAxis("Fire2");
        public float Horizontal => UnityEngine.Input.GetAxis("Horizontal");
        public float Vertical => UnityEngine.Input.GetAxis("Vertical");
        public float MouseY => UnityEngine.Input.GetAxis("Mouse Y");
        public float MouseX => UnityEngine.Input.GetAxis("Mouse X");

        public bool HasInput => Horizontal != 0 || Vertical != 0;
        public Vector3 Vector => new Vector3(Horizontal, 0, Vertical).normalized;
        public Vector3 TorqueVector => new Vector3(Vertical, 0, -Horizontal).normalized;
    }
}
