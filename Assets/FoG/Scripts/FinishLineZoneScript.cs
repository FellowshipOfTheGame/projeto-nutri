using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineZoneScript : MonoBehaviour
{
    public GameObject goPlayer;
    bool gpKart;
    int kartLevel;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("Player");
        gpKart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OK - Player + Finish Zone");
            gpKart = goPlayer.GetComponent<playerStats>().hasKart;
            kartLevel = goPlayer.GetComponent<playerStats>().GetKartLevel();
            if (gpKart == true &&  kartLevel >= 4)
            {
                goPlayer.GetComponent<playerStats>().hasKart = false;
                goPlayer.GetComponent<playerStats>().SetKartLevel(0);
            }
        }
    }


}
