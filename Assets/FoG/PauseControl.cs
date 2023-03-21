using FoG.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] InputActionReference pauseAction;
    [SerializeField] Button pauseButton;
    
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] Button resumeButton;
    [SerializeField] Button _homeButton;
    [SerializeField] ConfirmationPopup _homeConfirmation;

    bool IsPaused
    {
        get => _isPaused;
        set
        {
            pauseMenuUI.SetActive(value);
            _isPaused = value;
            Time.timeScale = value ? 0 : 1;
        }
    }

    bool _isPaused;

    void Awake()
    {
        IsPaused = false;
        pauseButton.onClick.AddListener(() => IsPaused = true);
        resumeButton.onClick.AddListener(() => IsPaused = false);
        _homeButton.onClick.AddListener(HomeButtonClicked);

        pauseAction.action.performed += context => IsPaused = !IsPaused;
    }

    void HomeButtonClicked()
    {
        _homeConfirmation.Open(goHome =>
        {
            if (goHome) 
                SceneManager.LoadScene("Menu");
        });
    }
}