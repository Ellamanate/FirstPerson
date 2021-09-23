namespace Modules.Spawn
{
    public interface IPooler<T1, T2>
    {
        T1 Get(T2 id);
        void Return(T1 obj);
        void ReturnAll();
    }
}
