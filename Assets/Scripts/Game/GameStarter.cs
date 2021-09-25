using UnityEngine;

using Modules.Spawn;

namespace MainGame
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private ItemsSpawner _spawner;

        [SerializeField]
        private MainGame _mainGame;

        [SerializeField]
        private int _itemsNumber;

        private void Awake()
        {
            Application.targetFrameRate = 120;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _mainGame.Init(_itemsNumber);

            StartGame();
        }

        public void StartGame()
        {
            _spawner.Spawn(_itemsNumber);

            _mainGame.Player.Enable();
        }
    }
}