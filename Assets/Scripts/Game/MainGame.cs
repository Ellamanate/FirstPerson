using UnityEngine;

using MainGame.PlayerModule;

namespace MainGame
{
    public class MainGame : MonoBehaviour
    {
        [SerializeField]
        private StorageCollectionCounter _counter;

        [SerializeField]
        private GameEnder _ender;

        [SerializeField]
        private Player _playerPrefab;

        private int _itemsNumber;

        public Player Player { get; private set; }

        private void OnEnable()
        {
            _counter.OnStore += Store;
        }

        private void OnDisable()
        {
            _counter.OnStore -= Store;
        }

        public void Init(int itemsNumber)
        {
            Player ??= Instantiate(_playerPrefab);

            _itemsNumber = itemsNumber;
        }

        private void Store()
        {
            if (_counter.ItemsNumber >= _itemsNumber)
            {
                _ender.EndGame();
            }
        }
    }
}