using System.Collections.Generic;

using UnityEngine;

using MainGame.Environment;

namespace MainGame.UserInterface
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _panel;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private CounterUI _counterPrefab;

        private List<CounterUI> _counters = new List<CounterUI>();

        public void Show(IReadOnlyCollection<ItemsStorage> storages)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            _panel.SetActive(true);

            foreach (var storage in storages)
            {
                var counterUI = Instantiate(_counterPrefab, _parent);
                counterUI.SetStorageData(storage.Visualizer.UIVisualization, storage.ItemsNumber);

                _counters.Add(counterUI);
            }
        }

        public void Hide()
        {
            _panel.SetActive(false);

            foreach (var counter in _counters)
            {
                Destroy(counter.gameObject);
            }

            _counters.Clear();
        }
    }
}