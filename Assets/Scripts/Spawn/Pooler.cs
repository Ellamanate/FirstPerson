using System.Linq;
using System.Collections.Generic;

namespace Modules.Spawn
{
    public class Pooler<T1, T2> : IPooler<T1, T2> where T1 : ISpawnable
    {
        private IFactory<T1, T2> _factory;

        private List<T1> _returnedObjects = new List<T1>();
        private List<Identifier<T1, T2>> _identifires = new List<Identifier<T1, T2>>();

        public Pooler(IFactory<T1, T2> factory)
        {
            _factory = factory;
        }

        public T1 Get(T2 id)
        {
            var validIdentifier = _identifires.Where(x => x.Id.Equals(id)).ToArray();

            if (validIdentifier.Length == 0)
            {
                return CreateNewObject(id);
            }

            var validObjects = _returnedObjects.Intersect(validIdentifier.Select(x => x.Object)).ToArray();

            if (validObjects.Length != 0)
            {
                var obj = validObjects[0];

                _returnedObjects.Remove(obj);

                obj.Spawn();

                return obj;
            }

            return CreateNewObject(id);
        }

        public void ReturnAll()
        {
            foreach (var obj in _identifires.Select(x => x.Object))
            {
                if (!_returnedObjects.Contains(obj))
                {
                    obj.Despawn();
                    obj.OnDespawn -= Return;
                }
            }
        }

        public void ReturnToDefault()
        {
            _returnedObjects.Clear();
            _identifires.Clear();
        }

        public void Dispose()
        {
            foreach (var identifier in _identifires)
            {
                identifier.Object.Dispose();
            }

            ReturnToDefault();
        }

        private T1 CreateNewObject(T2 id)
        {
            var obj = _factory.Create(id);

            obj.OnDespawn += Return;

            _identifires.Add(new Identifier<T1, T2>(obj, id));

            return obj;
        }

        private void Return(ISpawnable obj)
        {
            _returnedObjects.Add((T1)obj);
        }
    }
}