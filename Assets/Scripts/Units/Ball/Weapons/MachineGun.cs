using MyInput;
using UnityEngine;

namespace Units.Ball.Weapons
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private ParticleSystem _shoots;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (_inputSystem.RmbDown)
            {
                SwitchAttackState();
            }

            if (_inputSystem.RmbUp)
            {
                SwitchAttackState();
            }
        }
        
        private void SwitchAttackState()
        {
            ParticleSystem.MainModule module = _shoots.main;

            if (module.loop && _shoots.isPlaying)
            {
                module.loop = false;
            }
            else
            {
                module.loop = true;
                _shoots.Play();
            }
        }
    }
}
