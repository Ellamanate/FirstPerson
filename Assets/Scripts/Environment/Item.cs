using UnityEngine;

using Modules.Spawn;

namespace Environment
{
    public class Item : SpawnableObject, ICollectableObject
    {
        [SerializeField]
        private ItemTypes _type;

        [SerializeField]
        private Rigidbody _body;

        [SerializeField]
        private Collider _collider;

        public ItemTypes Type => _type;

        public override void Despawn()
        {
            gameObject.SetActive(false);

            Release();
        }

        public void Collect()
        {
            SwitchRigidbody(true);
        }

        public void Release()
        {
            SwitchRigidbody(false);
        }

        private void SwitchRigidbody(bool enabled)
        {
            _body.isKinematic = enabled;
            _body.detectCollisions = !enabled;
            _collider.enabled = !enabled;
        }
    }
}