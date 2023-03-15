using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class FoodCell : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _name;
        [SerializeField] Image _image;
        [SerializeField] Image _background;

        public void Refresh(Food food, Color bgColor)
        {
            if (food == null)
            {
                gameObject.SetActive(false);
                return;
            }
            
            gameObject.SetActive(true);
            _name.text = food.Name;
            _image.sprite = food.Image;

            _background.color = bgColor;
        }
    }
}