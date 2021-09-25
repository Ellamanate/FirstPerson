using System;

using UnityEngine;

using MainGame.Environment;

namespace Modules.Spawn
{
    public class ItemsFactory : MonoBehaviour, IFactory<Item, ItemTypes>
    {
        [SerializeField]
        private Item _cube;

        [SerializeField]
        private Item _capsule;

        [SerializeField]
        private Item _sphere;

        public Item Create(ItemTypes obj)
        {
            return obj switch
            {
                ItemTypes.Capsule => Instantiate(_capsule),
                ItemTypes.Cube => Instantiate(_cube),
                ItemTypes.Sphere => Instantiate(_sphere),
                _ => throw new NotImplementedException(),
            };
        }
    }
}