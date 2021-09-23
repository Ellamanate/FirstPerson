using UnityEngine;

namespace Player.Movement
{
    public class MovementInput : MonoBehaviour
    {
        private FirstPerson _inputActions;

        public Vector2 LookDirection => _inputActions.Player.Look.ReadValue<Vector2>();
        public Vector2 MoveDirection => _inputActions.Player.Move.ReadValue<Vector2>();

        private void Awake()
        {
            _inputActions = new FirstPerson();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }
    }
}