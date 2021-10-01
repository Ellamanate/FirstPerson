using UnityEngine;

using Modules.Spawn;

namespace MainGame.Adventure
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
            Application.targetFrameRate = 30;

            _mainGame.Init(_itemsNumber);
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _spawner.Spawn(_itemsNumber);

            _mainGame.Player.Enable();
        }
    }
}