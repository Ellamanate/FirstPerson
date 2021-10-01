using UnityEngine;

using MainGame.PlayerModule.Input;
using MainGame.PlayerModule.Camera;

using Extensions.Transform;

namespace MainGame.PlayerModule.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float MaxAngle = 89;

        [SerializeField]
        private PlayerInput _inputSystem;

        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private CameraMovement _cameraMovement;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _rotateSpeed;

        public Vector3 Forward { get; private set; }

        private Vector3 _gravity = new Vector3(0, -1, 0);
        private Vector2 _rotation;

        private void Update()
        {
            Look(_inputSystem.LookDirection);

            transform.rotation = Quaternion.LookRotation(Forward.ChangeY(0).normalized);

            _cameraMovement.LookUpdate(Forward);

            OnUpdate();
        }

        private void LateUpdate()
        {
            Move(_inputSystem.MoveDirection);

            OnLateUpdate();
        }

        protected virtual void OnUpdate() { }

        protected virtual void OnLateUpdate() { }

        private void Look(Vector2 rotate)
        {
            var scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
            _rotation.y += rotate.x * scaledRotateSpeed;
            _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaledRotateSpeed, -MaxAngle, MaxAngle);
            Forward = Quaternion.Euler(_rotation) * Vector3.forward;
        }

        private void Move(Vector2 direction)
        {
            var move = _cameraMovement.transform.rotation * new Vector3(direction.x, 0, direction.y) + _gravity;
            _controller.Move(move * _moveSpeed * Time.deltaTime);
        }
    }
}
