using UnityEngine;

namespace Utilities
{
    public class CopyLocation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _copyPosition = true;

        private void Update()
        {
            if(_copyPosition)
                transform.position = _target.position + _offset;
        }
    }
}