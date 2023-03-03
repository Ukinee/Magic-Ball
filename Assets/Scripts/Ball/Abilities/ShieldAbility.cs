using System.Collections;
using MyInput;
using UnityEngine;

namespace Ball.Abilities
{
    public class ShieldAbility : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private GameObject _shieldPrefab;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _duration;
        [SerializeField] private bool _endOnExit;

        private bool _isOnCooldown = false;
        private YieldInstruction _cooldownInstrucion;

        private void Start()
        {
            _cooldownInstrucion = new WaitForSeconds(_cooldown);
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (_inputSystem.C == false || _isOnCooldown) 
                return;

            Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
            StartCoroutine(StartCooldown());
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;

            yield return _cooldownInstrucion;

            _isOnCooldown = false;
        }
    }
}
