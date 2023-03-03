using UnityEngine;
using UnityEngine.Serialization;

namespace AQUAS_Lite //Original from Unity, changed namespace to avoid conflicts when importing official packages
{
    [AddComponentMenu("AQUAS Lite/Camera Navigation")]
    public class AQUAS_Lite_CamNav : MonoBehaviour
    {
        [SerializeField] private bool _freeLookEnabled = true;
        [SerializeField] private bool _showCursor = true;

        [SerializeField] private float _lookSpeed = 5f;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _sprintSpeed = 50f;

        private float m_yaw;
        private float m_pitch;

        void Start()
        {
            m_yaw = transform.rotation.eulerAngles.y;
            m_pitch = transform.rotation.eulerAngles.x;
            Cursor.visible = _showCursor;
        }

        void Update()
        {
            if (!_freeLookEnabled)
                return;

            m_yaw = (m_yaw + _lookSpeed * Input.GetAxis("Mouse X")) % 360f;
            m_pitch = (m_pitch - _lookSpeed * Input.GetAxis("Mouse Y")) % 360f;
            transform.rotation = Quaternion.AngleAxis(m_yaw, Vector3.up) * Quaternion.AngleAxis(m_pitch, Vector3.right);

            var speed = Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? _sprintSpeed : _moveSpeed);
            var forward = speed * Input.GetAxis("Vertical");
            var right = speed * Input.GetAxis("Horizontal");
            var up = speed * ((Input.GetKey(KeyCode.Q) ? 1f : 0f) - (Input.GetKey(KeyCode.E) ? 1f : 0f));
            transform.position += transform.forward * forward + transform.right * right + Vector3.up * up;
        }
    }
}