using IndependedScripts;
using MyInput;
using UnityEngine;

namespace Ball
{
    public class PortalGun : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Portal _red;
        [SerializeField] private Portal _blue;
        [SerializeField] private InputSystem _inputSystem;

        [SerializeField] private ParticleSystem _tmp;
        [SerializeField] private LayerMask _layerMask;

        private void Update()
        {
            if (_inputSystem.HasPortalInput == false)
                return;

            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out RaycastHit hit) == false)
                return;

            Instantiate(_tmp, hit.point, Quaternion.identity);

            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, _layerMask) == false)
                return;

            TeleportPortal(
                _inputSystem.Q
                    ? _red.transform
                    : _blue.transform,
                hit);
        }

        private void TeleportPortal(Transform portalTransform, RaycastHit hit)
        {
            Quaternion rotation = Quaternion.LookRotation(hit.normal);

            portalTransform.rotation = rotation;
            portalTransform.position = hit.point + portalTransform.forward * 0.05f;
        }
    }
}