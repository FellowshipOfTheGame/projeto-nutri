using System;
using UnityEngine;
using TMPro;

public class TimerTextManager : MonoBehaviour
{
    static float CURRENT_TIME;

    [SerializeField] TextMeshProUGUI _clockText;
    [SerializeField] GameOverScreen _gameOverScreen;

    [SerializeField] float minutes;
    [SerializeField] float seconds;

    void Start()
    {
        CURRENT_TIME = minutes * 60 + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (CURRENT_TIME > 0.0f)
        {
            CURRENT_TIME -= Time.deltaTime;

            if (CURRENT_TIME <= 0)
            {
                _gameOverScreen.GameOver();
                CURRENT_TIME = 0;
            }
            
            minutes = Mathf.FloorToInt(CURRENT_TIME / 60);
            seconds = Mathf.FloorToInt(CURRENT_TIME % 60);
            _clockText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    public static void AddTimer(float adding)
    {
        CURRENT_TIME += adding;
    }

}
