using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerScript : MonoBehaviour
    {
        public PlayerCollision playerCollision;
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
