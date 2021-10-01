using UnityEngine;

using MainGame.PlayerModule.Input;

namespace MainGame.Shooter
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private PlayerInput _playerPrefab;

        [SerializeField]
        private PlayerInput _player;

        public PlayerInput Player => Init();

        private void Start()
        {
            _player.Enable();

            Application.targetFrameRate = 30;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private PlayerInput Init()
        {
            _player ??= Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);

            return _player;
        }
    }
}