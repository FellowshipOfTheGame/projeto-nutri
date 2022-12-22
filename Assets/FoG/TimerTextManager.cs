using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextManager : MonoBehaviour
{
    public static float timing;

    public TextMeshProUGUI timeText;

    public GameObject myPanel;

    public float minutes;
    public float seconds;

    int quickint = 0;

    // Start is called before the first frame update
    void Start()
    {
        timing = minutes * 60 + seconds;
        timeText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timing >= 0.0f)
        {
            timing -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("Acabou o tempo");
            if(quickint == 0)
            {
                StartCoroutine(myPanel.GetComponent<GameOverScreen>().FadeIn());
                quickint++;
            }
        }
        minutes = Mathf.FloorToInt(timing/60);
        seconds = Mathf.FloorToInt(timing%60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);;
    }

    public static void AddTimer(float adding)
    {
        timing += adding;
    }

}
