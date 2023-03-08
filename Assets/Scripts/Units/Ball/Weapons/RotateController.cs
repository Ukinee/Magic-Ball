using UnityEngine;

namespace Units.Ball.Weapons
{
    public class RotateController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private const float LookAtDefaultDistance = 200f;

        private Vector3 _startRotation;

        private void Start()
        {
            _startRotation = transform.rotation.eulerAngles;
        }

        private void Update()
        {
            Ray cameraRay = _camera.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2, 0));
        
            Vector3 lookAt;

            lookAt = Physics.Raycast(cameraRay, out RaycastHit hit) ? 
                hit.point : 
                cameraRay.GetPoint(LookAtDefaultDistance);
        
            transform.LookAt(lookAt);
            transform.Rotate(_startRotation);
        }
    }
}