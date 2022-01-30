using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartScript : MonoBehaviour
{
    GameObject goPlayer;
    bool kart;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        kart = goPlayer.GetComponent<playerStats>().hasKart;
        Debug.Log("KART TEST == " + kart);
         // Too expensive. Have to fix this
        gameObject.SetActive(kart);
    }
}
