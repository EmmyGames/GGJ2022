using UnityEngine;

namespace GGJ2022.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool isGrounded;
        public Transform groundCheck;
        public float groundDistance;
        public LayerMask groundMask;
        public Transform lookDirTransform;
        public Movement movement;
        public PlayerScript playerScript;
        
        private Vector3 _direction;
        private Vector3 _lastDirection;
        private float _startCamRotation;

        private void Start()
        {
            _startCamRotation = lookDirTransform.eulerAngles.y;
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            // Check if the player is grounded by casting a sphere check from the player's feet towards the ground.
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            _direction = new Vector3(playerScript.playerInput.moveX, 0f, playerScript.playerInput.moveZ).normalized;
            movement.EntityMovement(isGrounded, playerScript.playerInput.isSprinting, lookDirTransform,
                _startCamRotation, _direction);
        }
        
        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }*/
    }
}
