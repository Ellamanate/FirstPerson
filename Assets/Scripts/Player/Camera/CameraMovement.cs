using UnityEngine;

namespace MainGame.PlayerModule.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _camera;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main.transform;
            _camera.parent = transform;
            _camera.localPosition = Vector3.zero;
            _camera.localRotation = Quaternion.identity;
        }

        public void LookUpdate(Vector3 forward)
        {
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}