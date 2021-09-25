﻿using System;

using UnityEngine;

using Extensions.Transform;
using Environment;

namespace Modules.Spawn
{
    public class ItemsSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private ItemsFactory _factory;

        [SerializeField]
        private BoxCollider _collider;

        [SerializeField]
        private Transform _parent;

        private IPooler<Item, ItemTypes> _pooler;

        private void Awake()
        {
            _pooler = new Pooler<Item, ItemTypes>(_factory);
        }

        public void Spawn(int number)
        {
            for (int i = 0; i < number; i++)
            {
                var values = Enum.GetValues(typeof(ItemTypes));
                int random = UnityEngine.Random.Range(0, values.Length);

                var item = _pooler.Get((ItemTypes)values.GetValue(random));
                item.transform.position = _collider.bounds.GetRandomPoint();
                item.transform.parent = _parent;
            }
        }
    }
}