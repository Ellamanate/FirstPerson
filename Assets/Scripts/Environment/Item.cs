using UnityEngine;

using Modules.Spawn;

namespace Environment
{
    public class Item : MonoBehaviour, ISpawnable
    {
        [SerializeField]
        private ItemTypes _type;

        public ItemTypes Type => _type;

        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void ReturnToDefault()
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}