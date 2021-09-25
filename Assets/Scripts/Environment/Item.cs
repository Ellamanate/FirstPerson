using UnityEngine;

using Modules.Spawn;

namespace MainGame.Environment
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

        public void Collect()
        {
            SwitchRigidbody(true);
        }

        public void Release()
        {
            SwitchRigidbody(false);
        }

        protected override void WhenDespawn()
        {
            gameObject.SetActive(false);

            Release();
        }

        private void SwitchRigidbody(bool enabled)
        {
            _body.isKinematic = enabled;
            _body.detectCollisions = !enabled;
            _collider.enabled = !enabled;
        }
    }
}