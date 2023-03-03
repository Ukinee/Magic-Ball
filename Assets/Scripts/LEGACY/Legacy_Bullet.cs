// using System.Collections;
// using UnityEngine;
//
// namespace LEGACY
// {
//     public class Bullet : MonoBehaviour, ISelfDestructable
//     {
//         [SerializeField] private float _speed = 1f;
//         [SerializeField] private float _maxLifeTime = 10f;
//         [SerializeField] private float _impactForce = 10f;
//         [SerializeField] private Transform _tail;
//         [SerializeField] private ParticleSystem _impactVfx;
//     
//         private Vector3 _lastTailPosition;
//         private Coroutine _destructCoroutine;
//     
//         private void OnEnable()
//         {
//             _lastTailPosition = _tail.position;
//             _destructCoroutine = StartCoroutine(Destruct(_maxLifeTime));
//         }
//     
//         private void Update()
//         {
//             Fly();
//         }
//     
//         private void Fly()
//         {
//             transform.Translate(Vector3.forward * _speed, Space.Self);
//     
//             Vector3 position = transform.position;
//             Vector3 direction = (position - _lastTailPosition);
//     
//             var ray = new Ray(_lastTailPosition, direction);
//     
//             //Debug.DrawLine(_lastTailPosition, position, Color.cyan);
//     
//             if (Physics.Raycast(ray, out RaycastHit hit, direction.magnitude))
//             {
//                 Destroy(gameObject);
//                 //EditorApplication.isPaused = true;
//     
//                 //ImpactHandler.Handle(hit, _impactForce, _impactVfx, transform.rotation);
//             }
//     
//             _lastTailPosition = _tail.position;
//         }
//     
//         public IEnumerator Destruct(float lifeDuration)
//         {
//             yield return new WaitForSeconds(lifeDuration);
//     
//             Destroy(gameObject);
//         }
//     
//         private void OnDestroy()
//         {
//             StopCoroutine(_destructCoroutine);
//         }
//     }
// }