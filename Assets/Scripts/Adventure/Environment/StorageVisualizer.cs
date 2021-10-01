using UnityEngine;

using TMPro;

namespace MainGame.Environment
{
    public class StorageVisualizer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _textMesh;

        [SerializeField]
        private Sprite _sprite;

        public Sprite UIVisualization => _sprite;

        public void SetNumber(int number)
        {
            _textMesh.text = number.ToString();
        }
    }
}