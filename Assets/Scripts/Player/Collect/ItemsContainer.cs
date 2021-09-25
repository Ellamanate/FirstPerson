using UnityEngine;

using Environment;
using Extensions.Transform;

namespace Player.TransportItems
{
    public class ItemsContainer : BaseContainer<Item>
    {
        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private Vector3 _grabPosition;

        [SerializeField]
        private float _speed;

        public override void UpdatePosition(Vector3 position, Vector3 forward)
        {
            if (HeldObject != null && _controller.enabled)
            {
                var move = GetGrabPosition(position, forward);
                _controller.Move((move - transform.position) * _speed * Time.deltaTime);
                HeldObject.transform.position = transform.position + _controller.center;
                HeldObject.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
            }
        }

        protected override void OnSetItem()
        {
            HeldObject.transform.localPosition = _controller.center;

            _controller.enabled = true;
        }

        protected override void OnRelease()
        {
            _controller.enabled = false;
        }

        private Vector3 GetGrabPosition(Vector3 position, Vector3 forward)
        {
            var pos = (forward * _grabPosition.z).ChangeY(_grabPosition.y);
            return position + pos + Vector3.Cross(pos, Vector3.up) * _grabPosition.x;
        }
    }
}