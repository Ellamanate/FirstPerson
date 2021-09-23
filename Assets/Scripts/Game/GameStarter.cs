using UnityEngine;

using Modules.Spawn;

namespace MainGame
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private ItemsSpawner _spawner;

        private void Start()
        {
            _spawner.Spawn(10);
        }
    }
}