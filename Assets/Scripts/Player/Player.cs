using UnityEngine;

using MainGame.PlayerModule.Input;

namespace MainGame.PlayerModule
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _input;

        private void OnEnable()
        {
            Enable();
        }

        private void OnDisable()
        {
            Disable();
        }

        public void Enable()
        {
            _input.Enable();
        }

        public void Disable()
        {
            _input.Disable();
        }
    }
}