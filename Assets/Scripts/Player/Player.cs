using UnityEngine;

using MainGame.PlayerModule.Input;
using MainGame.PlayerModule.TransportItems;
using MainGame.Environment;

namespace MainGame.PlayerModule
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _input;

        [SerializeField]
        private BaseContainer<Item> _container;

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
            _container.transform.parent = null;

            _input.Enable();
        }

        public void Disable()
        {
            _container.transform.parent = transform;
            _container.Release();

            _input.Disable();
        }
    }
}