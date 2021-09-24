using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnAction;

        private FirstPerson _inputActions;

        public Vector2 LookDirection => _inputActions.Player.Look.ReadValue<Vector2>();
        public Vector2 MoveDirection => _inputActions.Player.Move.ReadValue<Vector2>();

        private void Awake()
        {
            _inputActions = new FirstPerson();
            _inputActions.Player.Action.performed += Action;
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void Action(InputAction.CallbackContext context)
        {
            OnAction?.Invoke();
        }
    }
}