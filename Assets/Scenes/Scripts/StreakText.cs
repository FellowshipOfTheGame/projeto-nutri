using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakText : MonoBehaviour
{
    public Text scoreText;
    public GameObject goPlayer;
    public playerStats teste;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("Player");
        scoreText = gameObject.GetComponent<Text>();
        teste = goPlayer.GetComponent<playerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = teste.GetBarPoint().ToString();
    }
}
