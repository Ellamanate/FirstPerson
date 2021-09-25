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

        private void Drop()
        {
            _container.Release();
        }
    }
}