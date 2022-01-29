using UnityEngine;

namespace GGJ2022.Camera
{
    public class CameraController : MonoBehaviour
    {
        public float mouseSense;
        public Transform player;

        private float _xRotation;

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

            _xRotation -= mouseY;
            // Cap the look up/down direction.
            _xRotation = _xRotation switch
            {
                > 90f => 90f,
                < -90f => -90f,
                _ => _xRotation
            };
        
            // Look up and down.
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
            // Look left and right.
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
