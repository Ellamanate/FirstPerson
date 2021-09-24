using System;

namespace Modules.Spawn
{
    public interface ISpawnable : IDisposable
    {
        void Spawn();
        void Despawn();
    }
}
