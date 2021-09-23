using System;

namespace Modules.Spawn
{
    public interface ISpawnable : IDisposable
    {
        void Init();
        void ReturnToDefault();
    }
}
