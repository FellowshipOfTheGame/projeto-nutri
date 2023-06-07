using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FoG.Scripts.UI
{
    public class BookPage : MonoBehaviour
    {
        [Header("Left components")]
        [SerializeField] TextMeshProUGUI _title;
        [SerializeField] TextMeshProUGUI _leftText;
        [SerializeField] PostIt _postIt;
        
        [Header("Right components")]
        [SerializeField] TextMeshProUGUI _rightText;
        [SerializeField] FoodScrollViewer _foodScrollView;

        [Header("Data")]
        [SerializeField] PageData _introContent;
        [SerializeField] PageData _inNaturaContent;
        [SerializeField] PageData _processadoContent;
        [SerializeField] PageData _ultraContent;

        Dictionary<Nutripedia.Labels, PageData> _labelContent;

        void Awake()
        {
            _labelContent = new Dictionary<Nutripedia.Labels, PageData>()
            {
                { Nutripedia.Labels.Intro, _introContent },
                { Nutripedia.Labels.Natura, _inNaturaContent },
                { Nutripedia.Labels.Processado, _processadoContent },
                { Nutripedia.Labels.Ultra, _ultraContent }
            };
        }

        public void ChangePage(Nutripedia.Labels label)
        {
            PageData content = _labelContent[label];

            _title.text = content.Title;
            _leftText.text = content.LeftText;
            _postIt.Refresh(content.PostIt);

            _rightText.text = content.RightText;
            _rightText.gameObject.SetActive(!string.IsNullOrWhiteSpace(content.RightText));
            
            _foodScrollView.Refresh(content.FoodList, content.FoodBackgroundColor);
        }
    }
}