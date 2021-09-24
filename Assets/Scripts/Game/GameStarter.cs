using UnityEngine;

using Modules.Spawn;

namespace MainGame
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private ItemsSpawner _spawner;

        [SerializeField]
        private int _itemsNumber;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _spawner.Spawn(_itemsNumber);
        }
    }
}