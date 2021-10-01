using UnityEngine;

using MainGame.PlayerModule.TransportItems;
using MainGame.Environment;

using Extensions.Transform;

namespace MainGame.PlayerModule.Movement
{
    public class AdventureMovement : PlayerMovement
    {
        [SerializeField]
        private BaseContainer<Item> _container;

        protected override void OnUpdate()
        {
            _container.UpdatePosition(transform.position, Forward.ChangeY(0).normalized);
        }
    }
}