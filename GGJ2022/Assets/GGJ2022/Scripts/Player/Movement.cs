using UnityEngine;

namespace GGJ2022.Player
{
    public class Movement : MonoBehaviour
    {
        public float speed;
        public float sprintSpeed;
        public float walkBackMultiplier;
        public float walkSpeed;
        
        private float _angle;
        private CharacterController _controller;
        private const float GRAVITY = -20f;
        private Vector3 _lastDirection;
        private float _lookAngle;
        private Vector3 _moveDir;
        private float _targetAngle;
        private float _turnSmoothVelocity;
        private Vector3 _velocity = Vector3.zero;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }
        
        public void EntityMovement(bool isGrounded, bool isSprinting, Transform lookDirTransform, float startRotation, Vector3 direction)
        {
            if (isGrounded && _velocity.y < 0f)
            {
                //Reset the velocity that it had accumulated while on the ground
                _velocity.y = -2f;
            }
            
            speed = isSprinting && direction.z > 0f ? sprintSpeed : walkSpeed;
            if (direction.z < 0.01f)
                speed *= walkBackMultiplier;
            
            // Point the player at the camera.
            var eulerAngles = lookDirTransform.eulerAngles;
            _targetAngle = eulerAngles.y - startRotation;
            _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * direction;
            lookDirTransform.localEulerAngles = new Vector3(eulerAngles.x, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
            _controller.Move(speed * Time.deltaTime * _moveDir);
            
            _velocity.y += GRAVITY * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}
