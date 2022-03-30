using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text streakText;
    public Text multiplierText;
    public Text carState;
    public GameObject goPlayer;
    public playerStats playerstats;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("Player");
        playerstats = goPlayer.GetComponent<playerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerstats.GetPoints().ToString();
        streakText.text = playerstats.GetBarPoint().ToString();
        multiplierText.text = playerstats.GetMultPoint().ToString();
        carState.text = playerstats.GetKartState().ToString();
    }
}
