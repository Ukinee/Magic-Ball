using UnityEngine;

namespace LEGACY
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _cameraHolder;
        [SerializeField] private float _positionLerpSpeed;
        [SerializeField] private float _rotationLerpSpeed;
    
    
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _cameraHolder.position, _positionLerpSpeed * Time.deltaTime);   
            transform.rotation = Quaternion.Lerp(transform.rotation, _cameraHolder.rotation, _rotationLerpSpeed * Time.deltaTime);   
        }
    }
}
