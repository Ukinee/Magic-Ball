using System.Collections;
using UnityEngine;

namespace Units.Ball.Abilities
{
    public class DashVisual : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _dashSparklesVfx;
        [SerializeField] private ParticleSystem _dashVfx;
    
        private MeshRenderer[] _meshRenderers;

        private void Start()
        {
            _meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        }

        public void OnDash(Vector3 dashDirection, float dashDuration)
        {
            PlayVfx(dashDirection);

            StartCoroutine(HandleMeshVisuals(dashDuration));
        }

        private void PlayVfx(Vector3 dashDirection)
        {
            Quaternion rotation = Quaternion.LookRotation(-dashDirection);

            Instantiate(_dashSparklesVfx, transform.position, rotation);
            Instantiate(_dashVfx, transform.position, rotation);
        }

        private IEnumerator HandleMeshVisuals(float dashDuration)
        {
            ChangeVisibilityState();

            yield return new WaitForSeconds(dashDuration);

            ChangeVisibilityState();
        }

        private void ChangeVisibilityState()
        {
            foreach (MeshRenderer meshRenderer in _meshRenderers)
            {
                meshRenderer.enabled = !meshRenderer.enabled;
            }
        }
    }
}
