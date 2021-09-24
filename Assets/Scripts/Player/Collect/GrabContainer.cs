using UnityEngine;

using Environment;
using Extensions.Transform;

namespace Player.TransportItems
{
    public class GrabContainer : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private Transform _forward;

        [SerializeField]
        private Vector3 _grabPosition;

        public ICollectableObject HeldItem { get; private set; }

        public void UpdatePosition()
        {
            if (HeldItem != null && _controller.enabled)
            {
                _controller.Move(GetGrabPosition() - transform.position);
                HeldItem.transform.rotation = Quaternion.Euler(new Vector3(0, _forward.rotation.eulerAngles.y, 0));
            }
        }

        public void SetItem(ICollectableObject collectable)
        {
            HeldItem = collectable;
            HeldItem.Collect();
            HeldItem.transform.parent = transform;
            HeldItem.transform.localPosition = _controller.center;

            _controller.enabled = true;
        }

        public void Release()
        {
            _controller.enabled = false;

            HeldItem.Release();
            HeldItem.transform.parent = null;
            HeldItem = null;
        }

        private Vector3 GetGrabPosition()
        {
            var pos = _forward.forward.ChangeY(0).normalized * _grabPosition.z;
            return _forward.position + pos + Vector3.Cross(pos, Vector3.up) * _grabPosition.x;
        }
    }
}