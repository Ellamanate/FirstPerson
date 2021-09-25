using System;

using UnityEngine;

namespace MainGame.Environment
{
    public class ItemsStorage : MonoBehaviour
    {
        public event Action OnStore;

        [SerializeField]
        private StorageVisualizer _visualizer;

        [SerializeField]
        private ItemTypes _type;

        public StorageVisualizer Visualizer => _visualizer;

        public int ItemsNumber { get; private set; }

        private void Awake()
        {
            _visualizer.SetNumber(ItemsNumber);
        }

        public bool TryCollectItem(Item item)
        {
            if (item.Type == _type)
            {
                item.Despawn();

                ItemsNumber++;
                _visualizer.SetNumber(ItemsNumber);

                OnStore?.Invoke();

                return true;
            }

            return false;
        }

        public void ReturnToDefault()
        {
            ItemsNumber = 0;
            _visualizer.SetNumber(ItemsNumber);
        }
    }
}