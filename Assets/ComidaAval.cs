using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComidaAval : MonoBehaviour
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

        float porcentagem = ((float)intCollection[0])/((float)intCollection[3]);

        Debug.Log("Porcentagem: "+ porcentagem);

        if(porcentagem > 0.0f && porcentagem < 0.5f)
        {
            soulTex.text = "Você está mal";
        }
        else if(porcentagem > 0.5f && porcentagem < 0.75f)
        {
            soulTex.text = "Você foi bem, mas pode melhorar";
        }
        else
        {
            soulTex.text = "Você foi muito bem";
        }

        ///soulTex.text = "Porcentagem = " + ((intCollection[0]/intCollection[3])*100) + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
