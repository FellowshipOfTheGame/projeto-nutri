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
    
        [SerializeField] GameObject logoInitial;
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject characterSelection;
        [SerializeField] GameObject nutripedia;

        Dictionary<Screens, GameObject> screensReference;

        public static MenuController Instance { get; private set; }

        public void ChangeScreen(Screens from, Screens to)
        {
            ChangeScreen(screensReference[from], to);
        }
    
        public void ChangeScreen(GameObject from, Screens to)
        {
            from.SetActive(false);
            screensReference[to].SetActive(true);
        }

        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("ERROR! There are 2 MenuControllers, but you can only have ONE.");
                GameObject.Destroy(Instance);
            }
            Instance = this;
            
            clickToContinue.onClick.AddListener(ExitFromLogo);
        
            logoInitial.SetActive(true);
            mainMenu.SetActive(false);
            characterSelection.SetActive(false);
            nutripedia.SetActive(false);

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

        public void LoadGameScene()
        {
            SceneManager.LoadScene("Game");
        }

        void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
            else
            {
                Debug.Log("Destroying the oldest MenuController while maintaining the new one as the instance");
            }
        }
    }
}
