using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextManager : MonoBehaviour
{
    public static float timing;

    public TextMeshProUGUI timeText;

    public float minutes;
    public float seconds;

    // Start is called before the first frame update
    void Start()
    {
        timing = 100.0f;
        timeText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timing > 0.0f)
        {
            timing -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Fazer algo aaaaa");
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
