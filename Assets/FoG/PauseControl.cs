using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] InputActionReference pauseAction;

    public bool IsPaused
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

        pauseAction.action.performed += context => IsPaused = !IsPaused;
    }
}