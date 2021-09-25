using System;

namespace Modules.Spawn
{
    public interface ISpawnable : IDisposable
    {
        event Action<ISpawnable> OnDespawn;
        void Spawn();
        void Despawn();
    }
}
