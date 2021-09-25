using UnityEngine;

using Modules.Spawn;

namespace MainGame
{
    public class MainGame : MonoBehaviour
    {
        [SerializeField]
        private ItemsSpawner _spawner;

        [SerializeField]
        private StorageCounter _counter;

        [SerializeField]
        private int _itemsNumber;

        private void Awake()
        {
            Application.targetFrameRate = 120;
        }

        private void OnEnable()
        {
            _counter.OnStore += Store;
        }

        private void OnDisable()
        {
            _counter.OnStore -= Store;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _spawner.Spawn(_itemsNumber);
        }

        private void Store()
        {
            if (_counter.Counter >= _itemsNumber)
            {
                _counter.ResetToDefault();
                _spawner.Spawn(_itemsNumber);
            }
        }
    }
}