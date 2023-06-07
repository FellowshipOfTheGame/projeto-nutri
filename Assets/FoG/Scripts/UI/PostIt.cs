using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class PostIt : MonoBehaviour
    {
        [SerializeField] Image _image;
        [SerializeField] Button _openButton;
        [SerializeField] PostItPopup _postItPopup;

        PostItData _currentData;

        void Awake()
        {
            _openButton.onClick.AddListener(OpenPopup);
        }

        public void Refresh(PostItData data)
        {
            _currentData = data;
            
            if (data == null || data.ButtonImage == null)
            {
                gameObject.SetActive(false);
                return;
            }
            
            gameObject.SetActive(true);
            
            _image.sprite = data.ButtonImage;
        }

        void OpenPopup()
        {
            _postItPopup.Open(_currentData.Description);
        }
    }
}