using UnityEngine;

using Player.Input;
using Player.TransportItems;
using Environment;
using Extensions.Transform;

namespace Player.Movement
{
    public class Movement : MonoBehaviour
    {
        private const float MaxAngle = 89;

        [SerializeField]
        private PlayerInput _inputSystem;

        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private BaseContainer<Item> _container;

        [SerializeField]
        private Transform _camera;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _rotateSpeed;

        private Vector3 _gravity = new Vector3(0, -1, 0);
        private Vector2 _rotation;
        private Vector3 _forward;

        private void Update()
        {
            Look(_inputSystem.LookDirection);
        }

        private void LateUpdate()
        {
            Move(_inputSystem.MoveDirection);
            _container.UpdatePosition(transform.position, _forward.ChangeY(0).normalized);
            _camera.rotation = Quaternion.LookRotation(_forward, Vector3.up);
        }

        private void Look(Vector2 rotate)
        {
            var scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
            _rotation.y += rotate.x * scaledRotateSpeed;
            _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaledRotateSpeed, -MaxAngle, MaxAngle);
            _forward = Quaternion.Euler(_rotation) * Vector3.forward;
        }

        private void Move(Vector2 direction)
        {
            var move = Quaternion.Euler(0, _rotation.y, 0) * new Vector3(direction.x, 0, direction.y) + _gravity;
            _controller.Move(move.normalized * _moveSpeed * Time.deltaTime);
        }
    }
}
