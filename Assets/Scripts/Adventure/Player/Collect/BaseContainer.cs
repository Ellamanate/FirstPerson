using UnityEngine;

using MainGame.Environment;

namespace MainGame.PlayerModule.TransportItems
{
    public class BaseContainer<T> : MonoBehaviour where T : Object, ICollectable
    {
        public T HeldObject { get; private set; }

        public virtual void UpdatePosition(Vector3 position, Vector3 forward) { }

        public void SetItem(T collectable)
        {
            HeldObject = collectable;
            HeldObject.Collect();

            OnSetItem();
        }

        public void Release()
        {
            OnRelease();

            HeldObject?.Release();
            HeldObject = null;
        }

        protected virtual void OnSetItem() { }        
        protected virtual void OnRelease() { }
    }
}