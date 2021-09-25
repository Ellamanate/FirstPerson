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

        public virtual void Despawn()
        {
            OnDespawn?.Invoke(this);

            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}