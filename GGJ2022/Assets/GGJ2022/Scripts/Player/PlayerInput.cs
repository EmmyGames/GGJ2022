using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public bool isSprinting = false;
        public float moveX;
        public float moveZ;
        public PlayerScript playerScript;

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveZ = Input.GetAxisRaw("Vertical");
            if (playerScript.playerMovement.isGrounded)
                isSprinting = false || Input.GetButton("Sprint");
        }
    }
}
