using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    {
        //pauseMenuUI.transform.localScale = new Vector3(0, 0, 0);
        pauseMenuUI.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        //pauseMenuUI.transform.localScale = new Vector3(0, 0, 0);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Pause()
    {
        //pauseMenuUI.transform.localScale = new Vector3(1, 1, 1);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void testButton()
    {
        Debug.Log("Olá, Akira e Óliver!");
    }
}
