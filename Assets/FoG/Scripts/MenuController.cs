using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button startGame;

    void Start()
    {
        startGame.onClick.AddListener(LoadGameScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
