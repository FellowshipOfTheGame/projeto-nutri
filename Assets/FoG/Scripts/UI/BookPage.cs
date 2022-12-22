using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class BookPage : MonoBehaviour
    {
        [Serializable]
        struct PageContent
        {
            public string title;
            [TextArea] public string body;
            public RectTransform foodList;
        }
        
        [SerializeField] TextMeshProUGUI title;
        [SerializeField] TextMeshProUGUI body;
        [SerializeField] ScrollRect foodScrollView;

        [SerializeField] PageContent inNaturaContent;
        [SerializeField] PageContent processadoContent;
        [SerializeField] PageContent ultraContent;

        Dictionary<Nutripedia.Labels, PageContent> _labelContent;
        Nutripedia.Labels _currentLabel;

        void Awake()
        {
            _labelContent = new Dictionary<Nutripedia.Labels, PageContent>()
            {
                { Nutripedia.Labels.Natura, inNaturaContent },
                { Nutripedia.Labels.Processado, processadoContent },
                { Nutripedia.Labels.Ultra, ultraContent }
            };

            foreach (var labelContent in _labelContent)
            {
                labelContent.Value.foodList.gameObject.SetActive(false);
            }
        }

        public void ChangePage(Nutripedia.Labels label)
        {
            if (_currentLabel != Nutripedia.Labels.Intro)
            {
                _labelContent[_currentLabel].foodList.gameObject.SetActive(false);
            }
            
            if (label != Nutripedia.Labels.Intro)
            {
                _labelContent[label].foodList.gameObject.SetActive(true);
                foodScrollView.content = _labelContent[label].foodList;
                title.text = _labelContent[label].title;
                body.text = _labelContent[label].body;
            }
            else
            {
                title.text = "INTRO";
                body.text = "";
            }

            _currentLabel = label;
        }
    }
}