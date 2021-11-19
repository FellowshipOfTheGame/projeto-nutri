using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierText : MonoBehaviour
{
    public Text scoreText;
    public GameObject goPlayer;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("Player");
        scoreText = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = goPlayer.GetComponent<playerStats>().GetMultPoint().ToString();     
    }
}
