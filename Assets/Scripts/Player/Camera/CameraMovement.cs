using UnityEngine;

using MainGame.PlayerModule.Movement;

namespace MainGame.PlayerModule.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement _movement;

        private Transform _camera;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main.transform;
            _camera.parent = transform;
        }

        private void LateUpdate()
        {
            _camera.rotation = Quaternion.LookRotation(_movement.Forward, Vector3.up);
        }
    }
}