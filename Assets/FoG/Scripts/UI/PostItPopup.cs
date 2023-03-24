using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class PostItPopup : MonoBehaviour
    {
        [SerializeField] Button _backButton;
        [SerializeField] TextMeshProUGUI _content;

        void Awake()
        {
            _backButton.onClick.AddListener(ClosePopup);
        }

        public void Open(string content)
        {
            gameObject.SetActive(true);
            _content.text = content;
        }

        void ClosePopup()
        {
            gameObject.SetActive(false);
        }
    }
}