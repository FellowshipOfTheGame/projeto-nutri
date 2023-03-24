using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] PlayerSpawner _playerSpawner;
    [SerializeField] Button _menuButton;
    [SerializeField] Button _restartButton;
    [SerializeField] CanvasGroup _canvasGroup;

    [SerializeField] float _fadeDuration = 1;

    [Header("Resumo da jogada")]
    [SerializeField] TextMeshProUGUI _resumoSaudaveis;
    [SerializeField] TextMeshProUGUI _resumoNaoSaudaveis;
    [SerializeField, TextArea] string _textoSaudaveis;
    [SerializeField, TextArea] string _textoNaoSaudaveis;

    playerStats _playerStats;
    
    void Awake()
    {
        _menuButton.onClick.AddListener(GoToMenu);
        _restartButton.onClick.AddListener(RestartGame);
        _playerStats = _playerSpawner.currentPlayer.GetComponent<playerStats>();
    }

    public void GameOver()
    {
        gameObject.SetActive(true);

        _resumoSaudaveis.text = string.Format(_textoSaudaveis, _playerStats.GFOKEX);
        _resumoNaoSaudaveis.text = string.Format(_textoNaoSaudaveis, _playerStats.BFOKEX + _playerStats.TFOKEX);
        
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime / _fadeDuration;
            yield return null;
        }

        _canvasGroup.interactable = true;
        Time.timeScale = 0;
    }

    void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
