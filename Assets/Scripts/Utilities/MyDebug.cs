using UnityEditor;
using UnityEngine;

namespace Utilities
{
    public class MyDebug : MonoBehaviour
    {
        [SerializeField] private bool _isDebugging;

        private void FixedUpdate()
        {
            if(_isDebugging)
                Pause();
        }

        public static void Pause()
        {
            EditorApplication.isPaused = true;
        }

        public void InspectFrames()
        {
            _isDebugging = true;
        }
    }
}
