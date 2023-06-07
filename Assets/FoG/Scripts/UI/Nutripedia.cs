using System;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class Nutripedia : MonoBehaviour
    {
        public enum Labels
        {
            Intro,
            Natura,
            Processado,
            Ultra,
        }
        
        [Serializable]
        struct BookReferences
        {
            public GameObject root;
            public Button backButton;
            public Button labelIntro;
            public Button labelInNatura;
            public Button labelProcessado;
            public Button labelUltra;
        }

        [SerializeField] BookReferences chapterSelection;
        [SerializeField] BookReferences openBook;

        [SerializeField] BookPage bookPage;

        bool _isBookOpen = false;

        void Start()
        {
            chapterSelection.root.SetActive(true);
            openBook.root.SetActive(false);
            RegisterButtons(chapterSelection, false);
            RegisterButtons(openBook, true);
        }

        void RegisterButtons(BookReferences reference, bool state)
        {
            reference.backButton.onClick.AddListener(BackButtonClick);
            reference.labelIntro.onClick.AddListener(() => SwitchLabel(Labels.Intro));
            reference.labelInNatura.onClick.AddListener(() => SwitchLabel(Labels.Natura));
            reference.labelProcessado.onClick.AddListener(() => SwitchLabel(Labels.Processado));
            reference.labelUltra.onClick.AddListener(() => SwitchLabel(Labels.Ultra));
        }

        void BackButtonClick()
        {
            if (_isBookOpen)
            {
                SwitchBookState(false);
            }
            else
            {
                MenuController.Instance.ChangeScreen(gameObject, Screens.Main);
            }
        }

        void SwitchLabel(Labels label)
        {
            if (!_isBookOpen)
            {
                SwitchBookState(true);
            }
            
            bookPage.ChangePage(label);
        }

        void SwitchBookState(bool isOpen)
        {
            _isBookOpen = isOpen;
            chapterSelection.root.SetActive(!isOpen);
            openBook.root.SetActive(isOpen);
        }
    }
}