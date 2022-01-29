using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ2022.UI
{
    public class Start : MonoBehaviour 
    {
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}