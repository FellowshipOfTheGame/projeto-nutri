using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public enum Screens
    {
        Logo,
        Main,
        CharacterSelection,
        Nutripedia,
    }
    
    public class MenuController : MonoBehaviour
    {
        [SerializeField] Button clickToContinue;
        [SerializeField] Button startGame;
    
        [SerializeField] GameObject logoInitial;
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject characterSelection;
        [SerializeField] GameObject nutripedia;

        Dictionary<Screens, GameObject> screensReference;

        public void ChangeScreen(Screens from, Screens to)
        {
            ChangeScreen(screensReference[from], to);
        }
    
        public void ChangeScreen(GameObject from, Screens to)
        {
            from.SetActive(false);
            screensReference[to].SetActive(true);
        }

        void Start()
        {
            startGame.onClick.AddListener(LoadGameScene);
            clickToContinue.onClick.AddListener(ExitFromLogo);
        
            logoInitial.SetActive(true);
            mainMenu.SetActive(false);
            characterSelection.SetActive(false);

            screensReference = new Dictionary<Screens, GameObject>()
            {
                { Screens.Logo, logoInitial },
                { Screens.Main, mainMenu },
                { Screens.CharacterSelection, characterSelection },
                { Screens.Nutripedia, nutripedia },
            };
        }

        void ExitFromLogo()
        {
            Screens to = CharacterSelection.IsPlayerSelected() ? Screens.Main : Screens.CharacterSelection;
            ChangeScreen(Screens.Logo, to);
        }

        void LoadGameScene()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
