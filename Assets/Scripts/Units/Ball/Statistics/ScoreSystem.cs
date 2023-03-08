using UnityEngine;

namespace Units.Ball.Statistics
{
    public class ScoreSystem : MonoBehaviour
    {
        public int Score { get; private set; }

        public void Collect(int score)
        {
            Score += score;
        }
    }
}
