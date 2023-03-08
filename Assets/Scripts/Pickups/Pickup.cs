using Units.Ball.Statistics;
using UnityEngine;

namespace Pickups
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private int _scoreValue = 100;
    
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Pickup");
            
            if (other.TryGetComponent(out ScoreSystem collector) == false) 
                return;
        
            collector.Collect(_scoreValue);
            gameObject.SetActive(false);
        }
    }
}
