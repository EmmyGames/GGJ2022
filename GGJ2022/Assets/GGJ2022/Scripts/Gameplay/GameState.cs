using UnityEngine;

namespace GGJ2022.Gameplay
{
    public class GameState : MonoBehaviour
    {
        public static int Score;

        private void Awake()
        {
            Score = 0;
        }
        public void IncreaseScore()
        {
            Score++;
        }
    }
}
