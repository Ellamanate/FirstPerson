using System;
using System.Collections.Generic;

using UnityEngine;

using MainGame.Environment;

namespace MainGame
{
    public class StorageCollectionCounter : MonoBehaviour
    {
        public event Action OnStore;

        [SerializeField]
        private ItemsStorage[] _storages;

        public int ItemsNumber { get; private set; }

        private void OnEnable()
        {
            foreach (var storage in _storages)
            {
                storage.OnStore += UpCounter;
            }
        }

        private void OnDisable()
        {
            foreach (var storage in _storages)
            {
                storage.OnStore -= UpCounter;
            }
        }

        public IReadOnlyCollection<ItemsStorage> GetStorages()
        {
            return Array.AsReadOnly(_storages);
        }

        public void ResetToDefault()
        {
            ItemsNumber = 0;

            foreach (var storage in _storages)
            {
                storage.ReturnToDefault();
            }
        }

        private void UpCounter()
        {
            ItemsNumber++;

            OnStore?.Invoke();
        }
    }
}