using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _tail;
    
    private GameObject _testPrefab;
    private Vector3 _lastTailPosition;

    private void OnEnable()
    {
        _lastTailPosition = _tail.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed, Space.Self);
        
        Vector3 position = transform.position;
        Vector3 direction = (position - _lastTailPosition);

        var ray = new Ray(_lastTailPosition, direction);

        //Debug.DrawLine(_lastTailPosition, position, Color.cyan);

        if (Physics.Raycast(ray, out RaycastHit hit, direction.magnitude))
        {
            Destroy(gameObject);
            //EditorApplication.isPaused = true;
        }

        _lastTailPosition = _tail.position;
    }
}