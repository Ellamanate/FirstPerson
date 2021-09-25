using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace MainGame.PlayerModule.Input
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

        public void Enable()
        {
            _inputActions?.Enable();
        }

        public void Disable()
        {
            _inputActions?.Disable();
        }

        private void Action(InputAction.CallbackContext context)
        {
            OnAction?.Invoke();
        }
    }
}