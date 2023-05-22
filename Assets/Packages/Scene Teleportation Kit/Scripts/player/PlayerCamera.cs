using UnityEngine;

namespace Scene_Teleportation_Kit.Scripts.player
{
    public class PlayerCamera : MonoBehaviour {
        public Vector3 camOffset = new Vector3(0, -0.5f, 0.5f);
        public float pitch = 2f;
        public Transform playerTransform;
        public float minZoom = 5f;
        public float maxZoom = 15f;
    
        private float zoom = 8f;
        private float rotation = 0f;
        private float rotSpeed = 100f;

        private void Update() {
            zoom -= Input.GetAxis("Mouse ScrollWheel") * rotSpeed;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            rotation -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        }

        private void LateUpdate() {
            transform.position = playerTransform.position - camOffset * zoom;
            transform.LookAt(playerTransform.position + Vector3.up * pitch);
            transform.RotateAround(playerTransform.position, Vector3.up, -rotation);
        }
    }
}
