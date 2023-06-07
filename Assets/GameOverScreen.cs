using System.Collections;
using System.Globalization;
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

    [SerializeField] TextMeshProUGUI _score;

    [Header("Proporção de alimentos coletados")]
    [SerializeField, Range(0, 1)] float _targetProportion;
    [SerializeField] Color _colorAboveTarget;
    [SerializeField] Color _colorBelowTarget;
    [SerializeField] TextMeshProUGUI _proportion;
    [SerializeField, TextArea] string _proportionFormat;
    [SerializeField, TextArea] string _proportionNoFood;
    
    [Header("Feedback da jogada")]
    [SerializeField] TextMeshProUGUI _feedback;
    [SerializeField, TextArea] string _feedbackAboveTarget;
    [SerializeField, TextArea] string _feedbackBelowTarget;
    [SerializeField, TextArea] string _feedbackNoFood;

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

        _score.text = _playerStats.Points.ToString();
        
        if (_playerStats.FOKEX > 0)
        {
            var healthyFoodProportion = _playerStats.GFOKEX / (float) _playerStats.FOKEX;
            
            if (healthyFoodProportion >= _targetProportion)
            {
                _proportion.text = string.Format(_proportionFormat, ColorUtility.ToHtmlStringRGB(_colorAboveTarget),
                    healthyFoodProportion.ToString("0.##%", CultureInfo.CurrentCulture));
                _feedback.text = _feedbackAboveTarget;
            }
            else
            {
                _proportion.text = string.Format(_proportionFormat, ColorUtility.ToHtmlStringRGB(_colorBelowTarget),
                    healthyFoodProportion.ToString("0.##%", CultureInfo.CurrentCulture));
                _feedback.text = string.Format(_feedbackBelowTarget,
                    _targetProportion.ToString("0.##%", CultureInfo.CurrentCulture));
            }
        }
        else
        {
            _proportion.text = _proportionNoFood;
            _feedback.text = _feedbackNoFood;
        }
        
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
