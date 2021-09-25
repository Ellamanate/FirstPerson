using System;

using UnityEngine;

namespace Environment
{
    public class ItemsStorage : MonoBehaviour
    {
        public event Action OnStore;

        [SerializeField]
        private ItemTypes _type;

        public bool TryCollectItem(Item item)
        {
            if (item.Type == _type)
            {
                item.Despawn();

                OnStore?.Invoke();

                return true;
            }

            return false;
        }
    }
}