using UnityEngine;

using MainGame.UserInterface;

namespace MainGame.Adventure
{
    public class GameEnder : MonoBehaviour
    {
        [SerializeField]
        private StorageCollectionCounter _counter;

        [SerializeField]
        private EndGamePanel _endGamePanel;

        [SerializeField]
        private MainGame _mainGame;

        public void EndGame()
        {
            _mainGame.Player.Disable();
            _endGamePanel.Show(_counter.GetStorages());
        }
    }
}