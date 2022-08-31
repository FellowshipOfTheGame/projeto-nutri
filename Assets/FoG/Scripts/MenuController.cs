using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button clickToContinue;
    [SerializeField] Button startGame;
    
    [SerializeField] GameObject logoInitial;
    [SerializeField] GameObject mainButtons;

    void Start()
    {
        startGame.onClick.AddListener(LoadGameScene);
        clickToContinue.onClick.AddListener(LogoToMainButtons);
        
        logoInitial.SetActive(true);
        mainButtons.SetActive(false);
    }

    void LogoToMainButtons()
    {
        logoInitial.SetActive(false);
        mainButtons.SetActive(true);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
