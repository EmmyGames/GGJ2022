using GGJ2022.Gameplay;
using TMPro;
using UnityEngine;

namespace GGJ2022.UI
{
    public class GameOver : MonoBehaviour
    {
        public TextMeshProUGUI score;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            score.text = "Enemies Defeated: " + GameState.Score;
        }
    }
}
