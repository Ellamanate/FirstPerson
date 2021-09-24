using UnityEngine;

using Player.Input;
using Player.Sensors;
using Environment;

namespace Player.TransportItems
{
    public class GrabItems : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _inputSystem;

        [SerializeField]
        private ItemsDetector _detector;

        [SerializeField]
        private GrabContainer _container;

        private void OnEnable()
        {
            _inputSystem.OnAction += Action;
        }

        private void OnDisable()
        {
            _inputSystem.OnAction -= Action;
        }

        private void Action()
        {
            if (_container.HeldItem == null) 
            {
                Grab();
            }
            else
            {
                Drop();
            }
        }

        private void Grab()
        {
            if (_detector.TryGetNeraest(out Item item))
            {
                _container.SetItem(item);
            }
        }

        private void Drop()
        {
            _container.Release();
        }
    }
}