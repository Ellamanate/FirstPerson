using UnityEngine;

using MainGame.PlayerModule.Input;
using MainGame.PlayerModule.Sensors;
using MainGame.Environment;

namespace MainGame.PlayerModule.TransportItems
{
    public class GrabItems : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _inputSystem;

        [SerializeField]
        private ItemsDetector _itemsDetector;

        [SerializeField]
        private StorageDetector _storageDetector;

        [SerializeField]
        private BaseContainer<Item> _container;

        private void OnEnable()
        {
            _inputSystem.OnAction += Action;
        }

        private void OnDisable()
        {
            _inputSystem.OnAction -= Action;
        }

        public void Drop()
        {
            _container.Release();
        }

        private void Action()
        {
            if (_container.HeldObject == null) 
            {
                Grab();
            }
            else if (_storageDetector.TryGetStorage(out ItemsStorage storage))
            {
                PutInStorage(storage);
            }
            else
            {
                Drop();
            }
        }

        private void Grab()
        {
            if (_itemsDetector.TryGetNeraest(out Item item))
            {
                _container.SetItem(item);
            }
        }

        private void PutInStorage(ItemsStorage storage)
        {
            if (storage.TryCollectItem(_container.HeldObject))
            {
                _container.Release();
            }
            else
            {
                Drop();
            }
        }
    }
}