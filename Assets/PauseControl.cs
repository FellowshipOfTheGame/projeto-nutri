using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] InputActionReference pauseAction;

    bool IsPaused
    {
        get => _isPaused;
        set
        {
            pauseMenuUI.SetActive(value);
            Time.timeScale = value ? 0.00001f : 1f;
            _isPaused = value;
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
