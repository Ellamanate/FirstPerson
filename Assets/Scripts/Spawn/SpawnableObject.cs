using UnityEngine;

namespace Modules.Spawn
{
    public class SpawnableObject : MonoBehaviour, ISpawnable
    {
        public virtual void Spawn()
        {
            gameObject.SetActive(true);
        }

        public virtual void Despawn()
        {
            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}