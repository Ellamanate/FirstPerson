using System;

using UnityEngine;

namespace Modules.Spawn
{
    public class SpawnableObject : MonoBehaviour, ISpawnable
    {
        public event Action<ISpawnable> OnDespawn;

        public virtual void Spawn()
        {
            gameObject.SetActive(true);
        }

        public void Despawn()
        {
            OnDespawn?.Invoke(this);

            WhenDespawn();
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }

        protected virtual void WhenDespawn() 
        {
            gameObject.SetActive(false);
        }
    }
}