using UnityEngine;

using MainGame.PlayerModule.Input;
using MainGame.PlayerModule.TransportItems;

namespace MainGame.PlayerModule
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _input;

        [SerializeField]
        private GrabItems _grabItems;

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
            _grabItems.Drop();
        }
    }
}