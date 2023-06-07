using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComidaTextScript : MonoBehaviour
{
    GameObject player;
    playerStats pStats;
    int[] intCollection = new int[4];
    Text soulTex;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pStats = player.GetComponent<playerStats>();
        soulTex = gameObject.GetComponent<Text>();
        intCollection[0] = pStats.GFOKEX;
        intCollection[1] = pStats.BFOKEX;
        intCollection[2] = pStats.TFOKEX;
        intCollection[3] = pStats.FOKEX;

        soulTex.text = "Comidas pegas = " + intCollection[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
