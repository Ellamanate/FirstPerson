using System;

using UnityEngine;

using Environment;

namespace MainGame
{
    public class StorageCounter : MonoBehaviour
    {
        public event Action OnStore;

        [SerializeField]
        private ItemsStorage[] _storages;

        public int Counter { get; private set; }

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

        public void ResetToDefault()
        {
            Counter = 0;
        }

        private void UpCounter()
        {
            Counter++;

            OnStore?.Invoke();
        }
    }
}