using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ2022.UI
{
    public class Replay : MonoBehaviour
    {
        public void ReplayGame ()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
