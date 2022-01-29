using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public bool isSprinting = false;
        public float moveX;
        public float moveZ;
        public PlayerScript playerScript;

        private bool _fireGun;
        private bool _reload;
        private void Update()
        {
            GetInput();
            if(_fireGun)
                playerScript.playerShoot.ShootGun();
            if (_reload)
                StartCoroutine(playerScript.playerShoot.Reload());
        }

        private void GetInput()
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveZ = Input.GetAxisRaw("Vertical");
            if (playerScript.playerMovement.isGrounded)
                isSprinting = false || Input.GetButton("Sprint");
            _fireGun = Input.GetButtonDown("Fire1");
            _reload = Input.GetButton("Reload");
        }
    }
}
