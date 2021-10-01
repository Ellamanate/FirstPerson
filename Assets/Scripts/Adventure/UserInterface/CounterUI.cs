using UnityEngine;
using UnityEngine.UI;

namespace MainGame.UserInterface
{
    public class CounterUI : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private Text _text;

        public void SetStorageData(Sprite sprite, int number)
        {
            _image.sprite = sprite;
            _text.text = number.ToString();
        }
    }
}