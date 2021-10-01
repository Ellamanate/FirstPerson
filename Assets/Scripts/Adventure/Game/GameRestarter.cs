using UnityEngine;
using UnityEngine.UI;

using MainGame.UserInterface;

namespace MainGame
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField]
        private GameStarter _starter;

        [SerializeField]
        private EndGamePanel _endGamePanel;

        [SerializeField]
        private StorageCollectionCounter _counter;

        [SerializeField]
        private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
        }

        public void Restart()
        {
            _endGamePanel.Hide();

            _counter.ResetToDefault();

            _starter.StartGame();
        }
    }
}