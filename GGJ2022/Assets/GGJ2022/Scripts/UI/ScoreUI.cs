using TMPro;
using UnityEngine;

namespace GGJ2022.UI
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI score;
        private int _score;
        private void Start()
        {
            score.text = _score.ToString();
        }
    
        public void IncreaseScore()
        {
            _score++;
            score.text = _score.ToString();
        }
    }
}
