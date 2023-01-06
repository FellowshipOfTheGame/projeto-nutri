using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElemScript : MonoBehaviour
{
    /* Images Variables*/
    [SerializeField] public List<Sprite> Img = new List<Sprite>();
    [SerializeField] public int imgindex;
    public GameObject auxChildImg;
    Image spriterenderer;

    /* Player and points variables*/
    GameObject player;
    playerStats pStats;
    Text trivialTxt;
    [SerializeField]public int txtInd;
    int performance;
    
    /* Strings*/
    string[] strCollection = new string[5]
    {
        "Comida In Natura:",
        "Comida Processada",
        "Comida Ultra-processada",
        "NULL",
        "Reginaldo"
    };

    int[] intCollection = new int[4];


    // Start is called before the first frame update
    void Start()
    {
        /* Setting Images*/
        auxChildImg = gameObject.transform.GetChild(1).gameObject;
        spriterenderer = auxChildImg.GetComponent<Image>();
        spriterenderer.sprite = Img[imgindex];

        /* Setting player and txt*/
        player = GameObject.FindGameObjectWithTag("Player");
        pStats = player.GetComponent<playerStats>();
        trivialTxt = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        intCollection[0] = pStats.GFOKEX;
        intCollection[1] = pStats.BFOKEX;
        intCollection[2] = pStats.TFOKEX;
        intCollection[3] = pStats.FOKEX;

        trivialTxt.text = strCollection[txtInd] + " " + intCollection[txtInd].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
