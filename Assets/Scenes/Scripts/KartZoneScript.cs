using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartZoneScript : MonoBehaviour
{
    public GameObject goPlayer;
    bool gpKart;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OK - Player + Kartzone");
            gpKart = goPlayer.GetComponent<playerStats>().hasKart;
            if (!gpKart)
            {
                goPlayer.GetComponent<playerStats>().hasKart = true;
            }
        }
    }
}
